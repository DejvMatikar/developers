using Microsoft.AspNetCore.Http.Extensions;

namespace ExchangeRateService.Infrastructure;

public class LoggingEndpointFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var logger = context.HttpContext.RequestServices.GetService<ILogger<LoggingEndpointFilter>>()!;
        var request = context.HttpContext.Request;
        var response = context.HttpContext.Response;
        var identifier = context.HttpContext.TraceIdentifier;
        
        logger.LogInformation("{Method} {Api} started, {Id}.", request.Method, request.GetDisplayUrl(), identifier);
        var result = await next(context);
        logger.LogInformation("{Method} {Api} ended with {Result}, {Id}.", request.Method, request.GetDisplayUrl(), response.StatusCode, identifier);

        return result;
    }
}