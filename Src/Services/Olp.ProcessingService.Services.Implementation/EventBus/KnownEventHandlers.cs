using Olp.ProcessingService.WebApi.EventBus.Handlers;

namespace Olp.ProcessingService.WebApi.EventBus
{
    public static class KnownEventHandlers
    {
        public static IEnumerable<Type> Types
        {
            get => 
            [
                typeof(HasUserPermissionHandler)
            ];
        }
    }
}
