using AD.Business.Services.Internals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AD.Business.Services;

public static class Bootstrap
{
    private const string DefaultSection = "FileUpload";
    public static IServiceCollection BootstrapServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FileStorageSettings>(configuration.GetSection(DefaultSection));
        services.AddScoped<IFileService, SimpleFileService>();
        return services;
    }
}