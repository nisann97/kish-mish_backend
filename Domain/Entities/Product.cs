using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int Count { get; set; } = 0;
        public Category Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        //public ICollection<Comment> Comments { get; set; }
        public ICollection<ProductDetail> Details { get; set; }

    }
}