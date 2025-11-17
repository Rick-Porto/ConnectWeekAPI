using connectWeek.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace connectWeek.Api.Extensions;

public static class DatabaseExtension
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("Supabase"),
                b => b.MigrationsAssembly("connectWeek.Infra")));
    }
}
