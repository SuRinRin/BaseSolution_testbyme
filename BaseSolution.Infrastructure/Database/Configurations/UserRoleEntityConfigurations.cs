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
	public class UserRoleEntityConfigurations : IEntityTypeConfiguration<UserRoleEntity>
	{
		public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
		{
			builder.ToTable("UserRole");
			builder.HasKey(t => t.Id);
			builder.Property(x=>x.Id).ValueGeneratedOnAdd();
			builder.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x=>x.RoleId).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
