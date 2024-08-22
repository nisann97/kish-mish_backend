using System;
using Domain.Entities;
using Org.BouncyCastle.Bcpg.Sig;
using System.Reflection;

namespace Kish_mish.ViewModels.User
{
	public class HomeVM
	{
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<About> About { get; set; }
        //public List<Product> BestSellers { get; set; }
        //public List<Feature> Features { get; set; }
        //public List<Advertisement> Ads { get; set; }
        //public List<Comment> Comments { get; set; }
        //public List<Domain.Models.Statistic> Statistics { get; set; }
        //public Banner Banner { get; set; }
    }
}

