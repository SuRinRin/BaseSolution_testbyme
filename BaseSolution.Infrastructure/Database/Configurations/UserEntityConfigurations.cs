using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Database.Configurations
{
	public class UserEntityConfigurations : IEntityTypeConfiguration<UserEntity>
	{
		public void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			builder.ToTable("User");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x=>x.UserName).IsRequired().IsUnicode(true);
			builder.Property(x=>x.CreatedTime).HasDefaultValue(DateTimeOffset.UtcNow);
			builder.Property(x=>x.Email).IsRequired().IsUnicode(true);
		}
	}
}
