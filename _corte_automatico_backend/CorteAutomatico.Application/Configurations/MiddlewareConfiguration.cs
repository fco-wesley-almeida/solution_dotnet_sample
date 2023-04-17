using CorteAutomatico.Application.Middlewares;

namespace CorteAutomatico.Application.Configurations;

public static class MiddlewareConfiguration
{
    public static void UseMiddlewares(this IApplicationBuilder appBuilder)
    {
        appBuilder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}