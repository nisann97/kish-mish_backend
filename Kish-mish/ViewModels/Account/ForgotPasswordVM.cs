﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Kish_mish.ViewModels.Account
{
	public class ForgotPasswordVM
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}

