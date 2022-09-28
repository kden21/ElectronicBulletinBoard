using System.Net.Mime;
using System.Text.Json;
using ElectronicBoard.DataAccess.Exceptions;
using ElectronicBoard.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ElectronicBoard.Infrastructure.Middleware;

/// <summary>
/// Middleware для обработки ошибок.
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exceprion)
        {
            Console.WriteLine(exceprion);
            context.Response.ContentType = MediaTypeNames.Application.Json;
            
            if (exceprion is EntityNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync( JsonSerializer.Serialize(new
                {
                    traceId = context.TraceIdentifier, 
                    message = exceprion.Message
                }));
            }
            else if (exceprion is EntityUpdateException)
            {
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                await context.Response.WriteAsync( JsonSerializer.Serialize(new
                {
                    traceId = context.TraceIdentifier, 
                    message = exceprion.Message
                }));
            }
            else if (exceprion is EntityCreateException)
            {
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                await context.Response.WriteAsync( JsonSerializer.Serialize(new
                {
                    traceId = context.TraceIdentifier, 
                    message = exceprion.Message
                }));
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync( JsonSerializer.Serialize(new
                {
                    traceId = context.TraceIdentifier, 
                    message = "Произошла непредвиденная ошибка."
                }));
            }
        }
    }
}