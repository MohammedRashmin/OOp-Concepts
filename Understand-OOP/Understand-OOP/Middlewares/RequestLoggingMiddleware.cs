using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        _logger.LogInformation($"Incoming request: {context.Request.Method} {context.Request.Path}");

        await _next(context); // Pass the request to the next middleware

        stopwatch.Stop();
        _logger.LogInformation($"Response status: {context.Response.StatusCode}, Time taken: {stopwatch.ElapsedMilliseconds}ms");
    }
}
