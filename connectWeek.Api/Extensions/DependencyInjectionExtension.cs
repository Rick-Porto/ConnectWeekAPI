
using connectWeek.App.Interfaces;
using connectWeek.App.Services;
using connectWeek.Domain.Interfaces;
using connectWeek.Infra.Repositories;

namespace connectWeek.Api.Extensions;

public static class DependencyInjectionExtension
{
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.ConfigureServices();
        services.ConfigureRepositories();
        services.ConfigureNotificationServices();
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IDesafioService, DesafioService>();
        // Auth Services
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDesafioRepository, DesafioRepository>();
    }

    public static void ConfigureNotificationServices(this IServiceCollection services)
    {
    }
}
