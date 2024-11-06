using DataAccess;
using Microsoft.EntityFrameworkCore;
using Service.Settings;

namespace Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, FilmportalSettings settings)
    {
        services.AddDbContextFactory<FilmportalDbContext>(options =>
        {
            options.UseNpgsql(settings.FilmportalDbContextConnectionString);
        }, ServiceLifetime.Scoped);

    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<FilmportalDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}