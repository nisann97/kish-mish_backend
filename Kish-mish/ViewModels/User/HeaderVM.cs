﻿using System;
using Domain.Entities;

namespace Kish_mish.ViewModels.User
{
	public class HeaderVM
	{
        public Dictionary<string, string> Settings { get; set; }
        public string UserFullName { get; set; }
        public List<Category> Categories { get; set; }
    }
}

