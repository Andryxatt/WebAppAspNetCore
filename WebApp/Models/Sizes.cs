using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Sizes
    {
        [Key]
        public int SizeId { get; set; }
        public string SizeUA { get; set; }
        public string SizeUSA { get; set; }
        public string SizeEU { get; set; }
        public string SizeCM { get; set; }
        public virtual ICollection<SingleProduct> Products { get; set; }
    }
}
