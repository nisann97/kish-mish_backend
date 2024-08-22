using System;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Kish_mish.Areas.Admin.ViewModels.Product
{
	public class ProductEditVM
	{
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public string ProductPrice { get; set; }
        [Required]
        public int ProductCount { get; set; }
     
        public int CategoryId { get; set; }
        [Required]
        public List<ProductEditImageVM> ExistProductImages { get; set; }
        public List<IFormFile> NewProductImages { get; set; }
        public List<ProductDetail> Details { get; set; }
    }
}
