using EventBus.Base.Standard;

using Olp.ProcessingService.WebApi.EventBus.Events;
using Olp.ProcessingService.WebApi.EventBus.Handlers;


namespace Olp.ProcessingService.WebApi.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEventBus(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<HasUserPermissionEvent, HasUserPermissionHandler>();

            return app;
        }
    }
}
