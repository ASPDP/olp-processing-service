using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Olp.Infrastructure.EventBus.Interfaces;


namespace Olp.Infrastructure.EventBus.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> SubscribeToEventsAsync(this IApplicationBuilder app, IEnumerable<Type> handlerTypes, string subscriptionId = null)
        {
            var bus = app.ApplicationServices.GetRequiredService<IBus>();
            var serviceProvider = app.ApplicationServices;

            foreach (var handlerType in handlerTypes)
            {
                var handlerInterface = GetHandlerInterface(handlerType)
                    ?? throw new InvalidOperationException("Handler have to implement IEventHandler<T> interface.");
                var messageType = GetMessageType(handlerInterface)
                    ?? throw new InvalidOperationException("undefined event type.");

                await bus.PubSub.SubscribeAsync(
                    subscriptionId ?? string.Empty, messageType,
                    (message, messageType, cancellationToken) => OnMessageAsync(serviceProvider, handlerInterface, message, messageType, cancellationToken),
                    config => { });
            }

            return app;
        }

        private static async Task OnMessageAsync(IServiceProvider serviceProvider, Type handlerInterface, object message, Type messageType, CancellationToken cancellationToken = default)
        {
            using var scope = serviceProvider.CreateScope();
            IServiceProvider scopedServiceProvider = scope.ServiceProvider;

            var handler = scopedServiceProvider.GetRequiredService(handlerInterface);
            var methodInfo = handlerInterface.GetMethod("HandleMessageAsync")
                ?? throw new InvalidOperationException("Unexpected message handler.");
            var task = methodInfo.Invoke(handler, [message, cancellationToken]) as Task
                ?? throw new InvalidOperationException("Can't invoke handler.");

            await task;
        }

        private static Type? GetHandlerInterface(Type handlerType)
        {
            return handlerType.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>));
        }

        private static Type? GetMessageType(Type eventHandlerInterface)
        {
            return eventHandlerInterface?.GetGenericArguments()[0];
        }
    }
}
