using Infrastructure.HttpClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var productAPIURL = configuration.GetValue<string>("ProductEndpoint");

        services.AddRefitClient<IProductAPIClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7188"));

        services.AddRefitClient<IProductCategoryAPIClient>()
           .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7188"));

        return services;
    }
}