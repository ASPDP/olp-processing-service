using Microsoft.Extensions.DependencyInjection;
using EventBus.RabbitMQ.Standard.Configuration;
using EventBus.RabbitMQ.Standard.Options;

using Olp.RabbitMqTools.Infrastructure.EventBus.Services;


namespace Olp.RabbitMqTools.Infrastructure.EventBus.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, RabbitMqOptions rabbitMqOptions,
            IEnumerable<Type> handlerTypes)
        {
            services.AddRabbitMqConnection(rabbitMqOptions);
            services.AddRabbitMqRegistration(rabbitMqOptions);

            // Регистрация типов обработчиков EventBus
            foreach (Type eventHandlerType in handlerTypes)
            {
                services.AddTransient(eventHandlerType);
            }

            services.AddTransient<IEventBusService, EventBusService>();

            return services;
        }
    }
}
