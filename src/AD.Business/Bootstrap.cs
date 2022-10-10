using System.Reflection;
using AD.Business.Services;
using AD.Persistence.DataAccess;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AD.Business;

public static class Bootstrap
{
    public static IServiceCollection BootstrapAutoDock(this IServiceCollection services, IConfiguration configuration)
    {
        var svc = services;
        svc.AddMediatR(typeof(Bootstrap));
        
        services
            .BootstrapServices(configuration)
            .BootstrapDbContext(configuration);

        return services;
    }
}