using System.Net.Mime;
using System.Text.Json;
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
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            context.Response.ContentType = MediaTypeNames.Application.Json;
            
            switch (exception)
            {
                case EntityNotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync( JsonSerializer.Serialize(new
                    {
                        traceId = context.TraceIdentifier, 
                        message = exception.Message
                    }));
                    break;
                case EntityUpdateException:
                    context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                    await context.Response.WriteAsync( JsonSerializer.Serialize(new
                    {
                        traceId = context.TraceIdentifier, 
                        message = exception.Message
                    }));
                    break;
                case EntityCreateException:
                    context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                    await context.Response.WriteAsync( JsonSerializer.Serialize(new
                    {
                        traceId = context.TraceIdentifier, 
                        message = exception.Message
                    }));
                    break;
                case WrongDataException:
                    context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                    await context.Response.WriteAsync( JsonSerializer.Serialize(new
                    {
                        traceId = context.TraceIdentifier, 
                        message = "пользователь с таким логином уже существует"
                    }));
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync( JsonSerializer.Serialize(new
                    {
                        traceId = context.TraceIdentifier, 
                        message = "Произошла непредвиденная ошибка."
                    }));
                    break;
            }
        }
    }
}