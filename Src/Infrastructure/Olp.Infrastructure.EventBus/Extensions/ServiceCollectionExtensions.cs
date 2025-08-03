using EasyNetQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olp.Infrastructure.EventBus.Interfaces;
using Olp.Infrastructure.EventBus.Settings;


namespace Olp.Infrastructure.EventBus.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIntegrationEventHandlers(this IServiceCollection services, IEnumerable<Type> eventHandlers)
        {
            foreach (var eventHandlerType in eventHandlers)
            {
                var interfaceType = eventHandlerType.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>));

                services.AddTransient(interfaceType, eventHandlerType);
            }

            return services;
        }

        public static IServiceCollection AddCustomEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMQString = configuration.GetSection("RabbitMq").Get<RabbitMqSettings>()
                ?? throw new InvalidOperationException("Can't get RabbitMQ settings.");

            services.AddEasyNetQ(rabbitMQString.Connection).UseSystemTextJson();

            return services;
        }
    }
}
