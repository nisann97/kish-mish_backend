using System;
using System.ComponentModel.DataAnnotations;

namespace Kish_mish.ViewModels.Account
{
	public class LoginVM
	{
        [Required]
        public string EmailOrUsername { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

