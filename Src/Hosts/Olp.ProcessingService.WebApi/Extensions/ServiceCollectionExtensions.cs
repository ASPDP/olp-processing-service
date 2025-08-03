using Olp.ProcessingService.Services.Implementation;
using Olp.ProcessingService.Repositories.Implementation;
using Olp.Repositories.ProcessingAbstractions;
using Olp.Repositories.ProcessingImplementation;
using Olp.Services.ProcessingAbstractions;


namespace Olp.ProcessingService.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddTransient<IOperationRepository, OperationRepository>()
            .AddTransient<IOperationStepRepository, OperationStepRepository>()
            .AddTransient<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IOperationService, OperationService>();
    }
}
