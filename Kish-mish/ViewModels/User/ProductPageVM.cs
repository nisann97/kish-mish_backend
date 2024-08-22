using System;
using Domain.Entities;
using Kish_mish.Helpers;

namespace Kish_mish.ViewModels.User
{
	public class ProductPageVM
	{
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public Paginate<Product> Pagination { get; set; }
    }
}

