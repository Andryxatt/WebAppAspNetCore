using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public string Model { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; }
        public float PriceBy { get; set; }
        public  Brand Brand { get; set; }
        public  List<ProductPhotos> Photos { get; set; }

    }
}
