using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AD.Business.Services;

public static class Bootstrap
{
    public static IServiceCollection BootstrapServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        return services;
    }
}