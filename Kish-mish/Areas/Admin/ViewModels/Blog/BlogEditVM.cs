using System;
namespace Kish_mish.Areas.Admin.ViewModels.Blog
{
	public class BlogEditVM
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
    }
}

