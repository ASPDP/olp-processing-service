using Olp.ProcessingService.WebApi.EventBus.Handlers;


namespace Olp.Services.ProcessingImplementation.EventBus
{
    public static class KnownEventHandlers
    {
        public static IEnumerable<Type> Types
        {
            get => 
            [
                typeof(HasUserPermissionResultHandler)
            ];
        }
    }
}
