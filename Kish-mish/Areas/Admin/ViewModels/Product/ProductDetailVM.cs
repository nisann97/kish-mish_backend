using System;
using Domain.Entities;

namespace Kish_mish.Areas.Admin.ViewModels.Product
{
	public class ProductDetailVM
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }
        public int Count { get; set; }
        public List<ProductImageVM> ProductImages { get; set; }
    }
}

