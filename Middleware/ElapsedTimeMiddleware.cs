using System.Diagnostics;

namespace LibraryHub.Api.Middleware;

/// <summary>Adds an X-Elapsed-Ms header to every response.</summary>
public class ElapsedTimeMiddleware
{
    public const string HeaderName = "X-Elapsed-Ms";
    private readonly RequestDelegate _next;

    public ElapsedTimeMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        // Headers go out with the first byte of the body. By the time _next returns,
        // the endpoint may already have written it, so set the header just before
        // the response starts instead.
        context.Response.OnStarting(() =>
        {
            context.Response.Headers[HeaderName] = stopwatch.ElapsedMilliseconds.ToString();
            return Task.CompletedTask;
        });

        await _next(context);
    }
}