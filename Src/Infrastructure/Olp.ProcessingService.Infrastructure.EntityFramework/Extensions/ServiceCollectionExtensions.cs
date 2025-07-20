using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Olp.ProcessingService.Infrastructure.EntityFramework.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olp.ProcessingService.Infrastructure.EntityFramework.Extensions;

public static class EntityFrameworkInstaller
{
    public static IServiceCollection AddPostgresContext(this IServiceCollection services,
        DbSettings settings)
    {
        services.AddDbContext<ProcessingDbContext>(optionsBuilder => optionsBuilder
            .UseNpgsql(settings.ConnectionString)
        );

        return services;
    }
}
