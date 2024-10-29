using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        logger.LogInformation($"Handling {typeof(TRequest).Name}");
        var response = await next();
        stopwatch.Stop();

        Console.WriteLine($"İşlem süresi: {stopwatch.ElapsedMilliseconds} ms");
        return response;
    }
}