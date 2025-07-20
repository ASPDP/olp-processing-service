using Olp.ProcessingService.Infrastructure.EntityFramework;

namespace Olp.ProcessingService.WebApi.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> InitDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();
        using var db = scope.ServiceProvider.GetRequiredService<ProcessingDbContext>();

        var canConnect = await db.Database.CanConnectAsync();
        app.Logger.LogInformation("Can connect to database: {CanConnect}", canConnect);

        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();

        return app;
    }
}
