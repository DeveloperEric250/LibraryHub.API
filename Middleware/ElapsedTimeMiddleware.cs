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

        await _next(context);

        context.Response.Headers[HeaderName] = stopwatch.ElapsedMilliseconds.ToString();
    }
}