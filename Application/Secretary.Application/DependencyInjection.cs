﻿using Microsoft.Extensions.DependencyInjection;

namespace Secretary.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddMediatR(options =>
    {
      options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
    });

    return services;
  }
}