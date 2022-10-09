using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AD.Persistence.DataAccess;

public static class Bootstrap
{
    private const string section = "Default";
    
    public static IServiceCollection BootstrapDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(op =>
        {
            op.UseSqlServer(configuration.GetConnectionString(section));
            op.EnableThreadSafetyChecks();
            op.EnableSensitiveDataLogging();
            op.EnableDetailedErrors();
        });
        
        return services;
    }
}