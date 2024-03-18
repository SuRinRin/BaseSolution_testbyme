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
	public partial class ProductCategoryEntityConfigurations : IEntityTypeConfiguration<ProductCategoryEntity>
	{
		public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
		{
			builder.ToTable("ProductCategory");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Id).ValueGeneratedOnAdd();
			builder.HasOne(x=>x.Product).WithMany(x=>x.ProductCategories).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(x => x.Category).WithMany(x => x.ProductCategories).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
