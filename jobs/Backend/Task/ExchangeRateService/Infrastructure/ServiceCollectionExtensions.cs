using System.Reflection;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace ExchangeRateService.Infrastructure;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssemblyContaining<Program>(includeInternalTypes: true);
        services.AddFluentValidationAutoValidation();

        return services;
    }
    
    internal static IServiceCollection AddDomainApiServices(this IServiceCollection services)
    {
        var serviceTypes = typeof(IServices).Assembly
            .GetClassesAssignableTo<IServices>();

        foreach (var apiRoute in serviceTypes)
        {
            var route = (IServices)Activator.CreateInstance(apiRoute)!;
            route.Register(services);
        }

        return services;
    }
}