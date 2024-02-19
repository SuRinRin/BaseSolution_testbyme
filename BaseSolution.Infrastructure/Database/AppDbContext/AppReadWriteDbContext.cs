using BaseSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BaseSolution.Infrastructure.Database.AppDbContext
{
	public class AppReadWriteDbContext : DbContext
	{
        public AppReadWriteDbContext()
        {
              
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleReadOnlyDbContext).Assembly);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("SERVER=SURINRIN\\SQLEXPRESS01;Initial Catalog = BaseSolution_ByMe;Integrated Security=True;TrustServerCertificate=true");
			}
		}
		#region DbSet
		DbSet<UserEntity> Users { get; set; }
		DbSet<RoleEntity> Roles { get; set; }
		DbSet<UserRoleEntity> UserRole { get; set; }

		#endregion
	}
}
