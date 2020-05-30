using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SingleProduct
    {
        [Key]
        public Guid SingleProductId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public float PriceSale { get; set; }
        public int Count { get; set; }
        public int SizeId { get; set; }
        public Sizes Size { get; set; }

    }
}
