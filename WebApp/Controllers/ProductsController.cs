using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.ViewModels.Product;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext ctx;
        IWebHostEnvironment appEnvironment;
        public ProductsController(ApplicationDbContext _ctx, IWebHostEnvironment _appEnvironment)
        {
            ctx = _ctx;
            appEnvironment = _appEnvironment;
        }
        
        public IActionResult Index()
       {
            var products = (from prod in ctx.Products.Include(d => d.Photos)
                            select prod).ToList();
                          
            ViewBag.Brands = new SelectList(ctx.Brands, "BrandId", "Name");
            return View(products);
        }

        public IActionResult SaveProduct()
        {
            ViewBag.Brands = new SelectList(ctx.Brands, "BrandId", "Name");
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> NewProduct([FromForm] AddProductVM productVm)
        {

            Product product = new Product();
            product.BrandId = productVm.BrandId;
            product.Description = productVm.Description;
            product.Model = productVm.Model;
            product.PriceBy = productVm.PriceBy;
            if (ModelState.IsValid)
            {
                await ctx.Products.AddAsync(product);
                ctx.SaveChanges();
                if (productVm.Files != null)
                {
                    foreach (var uploadedFile in productVm.Files)
                    {
                        // путь к папке Files
                        string path = "/Files/" + uploadedFile.FileName;
                        // сохраняем файл в папку Files в каталоге wwwroot
                        using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                        ProductPhotos photo = new ProductPhotos { ProductId = product.ProductId, Path = path };
                        ctx.ProductPhotos.Add(photo);
                    }
                    ctx.SaveChanges();
                }
               
                
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult AddSingleProduct(Guid Id)
        {
            ViewBag.product = ctx.Products.Where(p => p.ProductId == Id).Include(d => d.Photos).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public IActionResult AddSingleProduct(Guid Id, List<int> countSizes, string price, List<int> sizesId)
        {
            var product = ctx.Products.Where(p => p.ProductId == Id).Include(d => d.Photos).FirstOrDefault();
            List<SingleProduct> singleProducts = new List<SingleProduct>();
            for (int i = 0; i < sizesId.Count(); i++)
            {
                SingleProduct singleProduct = new SingleProduct
                {
                    ProductId = Id,
                    Count = countSizes[i],
                    PriceSale = float.Parse(price),
                    SizeId = sizesId[i]
                };
                singleProducts.Add(singleProduct);
            }
           
            ctx.SingleProducts.AddRange(singleProducts);
            ctx.SaveChanges();
            return View("Index");
        }
    }
}