using System;
using System.ComponentModel.DataAnnotations;

namespace Kish_mish.Areas.Admin.ViewModels.About
{
	public class AboutCreateVM
	{
      
        [Required]
        public string Description { get; set; }
      
    }
}


