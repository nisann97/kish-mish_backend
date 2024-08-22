using System;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Kish_mish.Areas.Admin.ViewModels.Product
{
	public class ProductCreateVM
	{
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        public int ProductCount { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public List<IFormFile> Images { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }
}


