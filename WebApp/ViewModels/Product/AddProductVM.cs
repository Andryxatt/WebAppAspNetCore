using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels.Product
{
    public class AddProductVM
    {
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public float PriceBy { get; set; }
        public ICollection<IFormFile> Files { get; set; }
    }
}
