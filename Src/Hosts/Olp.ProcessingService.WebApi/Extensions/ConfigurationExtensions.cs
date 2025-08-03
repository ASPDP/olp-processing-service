using Olp.ProcessingService.WebApi.Settings;


namespace Olp.ProcessingService.WebApi.Extensions;

public static class ConfigurationExtensions
{
    public static AppSettings GetAppSettings(this IConfiguration configuration) => 
        configuration.Get<AppSettings>()
            ?? throw new InvalidOperationException("Не заданы настройки приложения.");
}
