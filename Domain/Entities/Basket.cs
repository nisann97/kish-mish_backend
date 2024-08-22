using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Basket : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

    }
}
