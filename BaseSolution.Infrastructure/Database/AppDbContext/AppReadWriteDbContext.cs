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
		public AppReadWriteDbContext(DbContextOptions<AppReadWriteDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppReadWriteDbContext).Assembly);
			SeedingData(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("SERVER=SURINRIN\\SQLEXPRESS01;Initial Catalog = BaseSolution_ByMe;Integrated Security=True;TrustServerCertificate=true");
			}
		}
		#region DbSet
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<RoleEntity> Roles { get; set; }
		public DbSet<UserRoleEntity> UserRole { get; set; }

		public DbSet<ProductEntity> Products { get; set; }

		public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

		public DbSet<CategoryEntity> Category { get; set; }

		public DbSet<CartEntity> Cart { get; set; }

		public DbSet<CartDetailEntity> CartDetail { get; set; }

		public DbSet<OrderEntity> Order { get; set; }

		public DbSet<OrderDetailEntity> OrderDetail { get; set; }
		#endregion
		private void SeedingData(ModelBuilder modelBuilder)
		{
			//seed user
			var seedUser = new UserEntity()
			{
				Id = Guid.NewGuid(),
				UserName = "SURINRIN",
				Password = "su1234",
				Email = "su2908@gmail.com",
				Status = Domain.Enums.UserStatus.Active,
				CreatedTime = DateTimeOffset.UtcNow
			};

			modelBuilder.Entity<UserEntity>(b => { b.HasData(seedUser); });
			//seed role
			var seedRole = new RoleEntity()
			{
				Id = Guid.NewGuid(),
				RoleName = "Admin",
				CreatedTime = DateTimeOffset.UtcNow,
				Description = "Quyền quản trị ứng dụng",

			};
			modelBuilder.Entity<RoleEntity>(b => { b.HasData(seedRole); });
			//seed product
			var seedProduct = new List<ProductEntity>()
			{
				new ProductEntity()
				{
					Id= Guid.NewGuid(),
					Name = "Ayaka",
					Quantity = 200,
					Describe = "Cực xinh đẹp",
					Series = "Genshin Impact",
					TradeMark = "ByMe",
					Status = Domain.Enums.ProductStatus.Active,
					CreatedTime= DateTimeOffset.UtcNow,
					Price = 157.78
				},
				new ProductEntity()
				{
					Id= Guid.NewGuid(),
					Name = "Nahida",
					Quantity = 200,
					Describe = "Cực xinh đẹp",
					Series = "Genshin Impact",
					TradeMark = "ByMe",
					Status = Domain.Enums.ProductStatus.Active,
					CreatedTime= DateTimeOffset.UtcNow,
					Price = 223.87
				},
				new ProductEntity()
				{
					Id= Guid.NewGuid(),
					Name = "Yamada Anna",
					Quantity = 200,
					Describe = "Cực xinh đẹp",
					Series = "Boku no Kokoro no Yabai Yatsu",
					TradeMark = "ByMe",
					Status = Domain.Enums.ProductStatus.Active,
					CreatedTime= DateTimeOffset.UtcNow,
					Price = 1000.67
				}
			};
			modelBuilder.Entity<ProductEntity>(b => { b.HasData(seedProduct); });
			var seedCategory = new List<CategoryEntity>()
			{
				new CategoryEntity(){
					Id = Guid.NewGuid(),
					Name= "Scale Figures",
					CreatedTime = DateTimeOffset.UtcNow,		
				},

				new CategoryEntity(){
					Id = Guid.NewGuid(),
					Name= "Nendoroid",
					CreatedTime = DateTimeOffset.UtcNow,
				}
			};
			modelBuilder.Entity<CategoryEntity>(b => { b.HasData(seedCategory); });

		}
	}
}
