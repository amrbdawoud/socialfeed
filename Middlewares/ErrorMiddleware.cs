using System.Globalization;
using socialfeed.Models;

namespace Middleware.Example;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Call the next delegate/middleware in the pipeline.
            await _next(context);

        }
        catch (socialfeed.Errors.BaseException e)
        {
            context.Response.StatusCode = e.StatusCode;
            await context.Response.WriteAsJsonAsync(e.Message);

        }
        catch (Exception e)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync($"internal server error: {e.Message}");
        }
    }
}
