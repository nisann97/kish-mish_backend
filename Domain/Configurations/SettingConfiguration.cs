using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
	public class SettingConfiguration : IEntityTypeConfiguration<Setting>
	{
		public void Configure(EntityTypeBuilder<Setting> builder)
		{
		}
	}
}

