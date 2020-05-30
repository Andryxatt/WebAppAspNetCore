using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
    }
}
