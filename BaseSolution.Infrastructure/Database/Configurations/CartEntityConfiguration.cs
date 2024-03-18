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
	public partial class CartEntityConfiguration : IEntityTypeConfiguration<CartEntity>
	{
		public void Configure(EntityTypeBuilder<CartEntity> builder)
		{
			builder.ToTable("Cart");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Id).ValueGeneratedOnAdd();
			builder.Property(c => c.TotalQuantity).HasDefaultValue(0).HasPrecision(5);
			builder.Property(c => c.TotalPrice).HasDefaultValue(0).HasPrecision(5);
			builder.HasOne(x => x.User).WithOne(x => x.Cart).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
