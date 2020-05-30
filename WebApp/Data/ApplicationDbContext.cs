using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductPhotos> ProductPhotos { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<MultipleProduct> MultipleProducts { get; set; }
        public DbSet<SingleProduct> SingleProducts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
