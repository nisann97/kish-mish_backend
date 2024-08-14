using System;
using System.ComponentModel.DataAnnotations;

namespace Kish_mish.Areas.Admin.ViewModels.Slider
{
	public class SliderCreateVM
	{
        [Required]
        public IFormFile SliderImage { get; set; }
    }
}

