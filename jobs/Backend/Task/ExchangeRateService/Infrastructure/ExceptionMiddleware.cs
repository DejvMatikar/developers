using Microsoft.AspNetCore.Mvc;

namespace ExchangeRateService.Infrastructure;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException e)
        {
            ProblemDetails problem = new();
            problem.Title = "Validation Failed";
            problem.Status = StatusCodes.Status400BadRequest;
            problem.Extensions.Add("errors", e.Errors.Select(x=> new
            {
                x.PropertyName, x.ErrorMessage
            }));

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}