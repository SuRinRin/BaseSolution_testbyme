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
	public partial class CartDetailEntityConfiguration : IEntityTypeConfiguration<CartDetailEntity>
	{
		public void Configure(EntityTypeBuilder<CartDetailEntity> builder)
		{
			builder.ToTable("CartDetail");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Id).ValueGeneratedOnAdd();
			builder.Property(c=>c.Quantity).HasDefaultValue(1);
			builder.Property(c => c.Price).HasPrecision(8, 2);
			builder.HasOne(x => x.Cart).WithMany(x => x.CartDetails).HasForeignKey(x => x.CartId).OnDelete(DeleteBehavior.NoAction);	
			builder.HasOne(x => x.ProductCategory).WithMany(x => x.CartDetail).HasForeignKey(x => x.ProductCategoryId).OnDelete(DeleteBehavior.NoAction);

		}
	}
}
