using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class MultipleProduct
    {
        [Key]
        public Guid MultipleProductId { get; set; }
        public Guid ProductId { get; set; }
        public int PairsInBox { get; set; }
        public string SizesBox { get; set; }
        public int CountBoxes { get; set; }
        public int Pairs { get; set; }
        public float PriceSale { get; set; }
    }
}
