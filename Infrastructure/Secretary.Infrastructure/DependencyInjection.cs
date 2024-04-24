using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Secretary.Application.Common;
using Secretary.Infrastructure.Persistence;

namespace Secretary.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
  {
    _ = AddPersistence(services);

    return services;
  }

  private static IServiceCollection AddPersistence(IServiceCollection services)
  {
    services.AddDbContext<SecretaryDbContext>(options =>
      options.UseSqlite("Data Source = Secretary.db"));

    services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<SecretaryDbContext>());

    return services;
  }
}