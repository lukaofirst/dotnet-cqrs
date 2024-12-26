using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infra.Data;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
	public static class DependencyContainer
	{
		public static IServiceCollection StartServices(this IServiceCollection services, IConfiguration config)
		{
			// Database
			services.AddDbContext<DataContext>(opt =>
				opt.UseSqlServer(
					config.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName)
				)
			);

			// Repositories
			services.AddScoped<IPersonRepository, PersonRepository>();

			// AutoMapper
			services.AddAutoMapper(typeof(DomainToDTO));
			services.AddAutoMapper(typeof(DomainToCommand));

			// Mediator
			var myHandlers = AppDomain.CurrentDomain.Load("Application");
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));

			return services;
		}
	}
}
