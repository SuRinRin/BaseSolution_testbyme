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
	public partial class OrderDetailEntityConfigurations : IEntityTypeConfiguration<OrderDetailEntity>
	{
		public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
		{
			builder.ToTable("OrderDetail");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Id).ValueGeneratedOnAdd();
			builder.Property(c => c.Note).IsRequired(false).HasDefaultValue("Unknow").HasMaxLength(255).IsUnicode(true); 
			builder.Property(c => c.Quantity).HasPrecision(5); 
			builder.Property(c => c.Price).HasPrecision(5);
			builder.HasOne(c => c.OrderEntity).WithMany(x => x.OrderDetail).HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(c => c.ProductCategory).WithMany(x => x.OrderDetail).HasForeignKey(x=>x.ProductCategoryId).OnDelete(DeleteBehavior.NoAction);





		}
	}
}
