using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Implements.Repositories.ReadOnly;
using BaseSolution.Infrastructure.Implements.Repositories.ReadWrite;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseSolution.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppReadOnlyDbContext>(options =>
            {
                // Configure your DbContext options here
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddDbContextPool<AppReadWriteDbContext>(options =>
            {
                // Configure your DbContext options here
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
			services.AddDbContextPool<ExampleReadOnlyDbContext>(options =>
			{
				// Configure your DbContext options here
				options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
			});

			services.AddDbContextPool<ExampleReadWriteDbContext>(options =>
			{
				// Configure your DbContext options here
				options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
			});

			services.AddTransient<ILocalizationService, LocalizationService>();
            services.AddTransient<IUserReadOnlyRepoisitory, UserReadOnlyRepoisitory>();
            services.AddTransient<IUserReadWriteRepoisitory, UserReadWriteRepoisitory>();
			services.AddTransient<IExampleReadOnlyRepository, ExampleReadOnlyRepository>();
			services.AddTransient<IExampleReadWriteRepository, ExampleReadWriteRepository>();

			return services;
        }
    }
}