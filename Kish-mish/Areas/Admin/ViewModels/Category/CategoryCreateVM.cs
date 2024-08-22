using System;
using System.ComponentModel.DataAnnotations;

namespace Kish_mish.Areas.Admin.ViewModels.Category
{
	public class CategoryCreateVM
	{
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

    }
}

