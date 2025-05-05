using Catalog.Data;
using Catalog.Data.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data;

namespace Catalog;

public static class CatalogModule
{
  public static IServiceCollection AddEshopCatalogModule(this IServiceCollection services, IConfiguration configuration)
  {
    // Add services to the container.
    // 1. Api Endpoint services

    // 2. Application Use Case services
    // 3. Data - Infrastructure services
    // services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
    // services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
    services.AddScoped<IDataSeeder, CatalogDataSeeder>();
    services.AddDbContext<CatalogDbContext>((sp, options) =>
    {
      options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
      options.UseNpgsql(configuration.GetConnectionString("Database"));
    });

    return services;
  }

  public static IApplicationBuilder UseEshopCatalogModule(this IApplicationBuilder app)
  {
    app.UseMigration<CatalogDbContext>();
    return app;
  }
}
