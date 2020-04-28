using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MarketWebCoreApi.Middleware
{
    /// <summary>
    /// Класс для логирования запросов
    /// </summary>
    public class RequestLogMiddleware
    {
        // TODO: реализовать DI ILogger
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public RequestLogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLogMiddleware>();
        }

        /// <summary>
        /// Метод выполнения
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            string requestId = context.TraceIdentifier;
            _logger.LogInformation("Request {id} starting {Protocol} {Method} {Scheme}://{Host}{Path}",
                requestId,
                context.Request.Protocol,
                context.Request.Method,
                context.Request.Scheme,
                context.Request.Host,
                context.Request.Path);
            var watch = Stopwatch.StartNew();
            await _next.Invoke(context);
            watch.Stop();
            _logger.LogInformation("Request {id} finished in {duration}ms, code - {StatusCode}",
                requestId,
                watch.ElapsedMilliseconds,
                context.Response.StatusCode);
        }
    }
}