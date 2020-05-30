using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApp.Models
{
    public class ProductPhotos
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public byte[] MyProperty { get; set; }
        public string Path { get; set; }
    }
}
