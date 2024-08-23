using System;
using Domain.Entities;
using Kish_mish.Areas.Admin.ViewModels.Product;

namespace Kish_mish.ViewModels.Products
{
	public class ProductDetailPageVM
	{
        public ProductDetailVM Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
   
    }
}

