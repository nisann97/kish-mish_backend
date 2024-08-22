using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
	public class CompanyValue : BaseEntity
	{
	
		public string Title { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }

	}
}

