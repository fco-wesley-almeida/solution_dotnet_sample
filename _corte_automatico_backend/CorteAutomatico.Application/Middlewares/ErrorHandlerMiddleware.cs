using CorteAutomatico.Application.Controllers;
using CorteAutomatico.Core.Exceptions;

namespace CorteAutomatico.Application.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ErrorHandlerMiddleware(
        RequestDelegate next, 
        ILoggerFactory log
    ){
        _next = next;
        _logger = log.CreateLogger("Infinity");
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (CustomException e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = e.StatusCode();
            await httpContext.Response.WriteAsJsonAsync(e.Response());
        }
        catch (ArgumentException e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 400;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                StatusCode = 400,
                Message = e.Message 
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                Message = "Ocorreu um erro inesperado no processamento da sua solicitação. Tente novamente dentro de alguns minutos. Se a situação persistir, contate suporte."
            });
        }
    }
}