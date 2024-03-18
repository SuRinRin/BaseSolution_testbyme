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
	public partial class ProductEntityConfigurations : IEntityTypeConfiguration<ProductEntity>
	{
		public void Configure(EntityTypeBuilder<ProductEntity> builder)
		{
			builder.ToTable("Product");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Id).ValueGeneratedOnAdd();
			builder.Property(c => c.Name).IsRequired().HasMaxLength(255).IsUnicode(true);
			builder.Property(c => c.Quantity).IsRequired().HasPrecision(5);
			builder.Property(c => c.Describe).IsRequired().HasMaxLength(255).HasDefaultValue("Unknow").IsUnicode(true); 
			builder.Property(c => c.Price).IsRequired().HasPrecision(8,2);
			builder.Property(c => c.Series).IsRequired().HasMaxLength(255).HasDefaultValue("Unknow").IsUnicode(true);
			builder.Property(c => c.TradeMark).IsRequired().HasMaxLength(255).HasDefaultValue("Unknow").IsUnicode(true);

		}
	}
}
