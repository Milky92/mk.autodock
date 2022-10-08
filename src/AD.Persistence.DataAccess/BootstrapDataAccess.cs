using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AD.Persistence.DataAccess;

public static class BootstrapDataAccess
{
    private const string section = "Default";
    
    public static IServiceCollection BootstrapDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppContext>(op =>
        {
            op.UseSqlServer(configuration.GetConnectionString(section));
            op.EnableThreadSafetyChecks();
            op.EnableSensitiveDataLogging();
            op.EnableDetailedErrors();
        });
        
        return services;
    }
}