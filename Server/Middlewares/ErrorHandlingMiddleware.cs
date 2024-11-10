using System.Net;
using Application.Exceptions;

namespace Server.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException ex)
        {
            // Manejo específico para ValidationException
            logger.LogError(ex, message: "Error de validación: {Message}", ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Errores de validación",
                Errors = ex.Errors
            }.ToString() ?? string.Empty);
        }
        catch (Exception ex)
        {
            // Manejo general para otras excepciones
            logger.LogError(ex, message: "Ocurrió un error inesperado.");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Ocurrió un error inesperado. Intente nuevamente más tarde."
            }.ToString() ?? string.Empty);
        }
    }
}