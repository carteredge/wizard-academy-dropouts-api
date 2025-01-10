
namespace WizardAcademyDropouts.Middleware;

using System.Net;


public class ResponseHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseHandlerMiddleware(RequestDelegate next) { _next = next; }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Response.Body == default)
        {

            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsync("Not found.");
        }
        await _next(context);
    }
}

public static class ResponseHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseResponseHandler(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ResponseHandlerMiddleware>();
}