using System;
using Domain.Common;

namespace Domain.Entities
{

    public class ProductDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public float Price { get; set; }

    }

}