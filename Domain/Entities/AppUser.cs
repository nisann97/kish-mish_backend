using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
	public class AppUser : IdentityUser
	{
        public string FullName { get; set; }
        //public ICollection<Basket> Baskets { get; set; }
        //public ICollection<Comment> Comments { get; set; }
    }
}

