using System;
using System.ComponentModel.DataAnnotations;

namespace Kish_mish.Areas.Admin.ViewModels.Slider
{
	public class SliderEditVM
	{
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
    }
}

