using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Olp.Infrastructure.EntityFramework.ProcessingContext.Settings;


namespace Olp.Infrastructure.EntityFramework.ProcessingContext.Extensions;

public static class EntityFrameworkInstaller
{
    public static IServiceCollection AddPostgresContext(this IServiceCollection services, DbSettings settings)
    {
        services.AddDbContext<ProcessingDbContext>(optionsBuilder => optionsBuilder
            .UseNpgsql(settings.ConnectionString)
        );

        return services;
    }
}
