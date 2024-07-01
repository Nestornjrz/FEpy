using Serilog.Context;

namespace FEpy.Api.Middleware
{
    public class RequestContextMiddleware
    {
        private const string CorrelationIdHeaderName = "X-Correlation-ID";

        private readonly RequestDelegate _next;

        public RequestContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext httpContext)
        {
            using (LogContext.PushProperty("CorrelationId", GetCorrelationId(httpContext)))
            {
                return _next(httpContext);
            }

        }

        private static string GetCorrelationId(HttpContext httpContext)
        {
            httpContext.Request.Headers.TryGetValue(CorrelationIdHeaderName, out var correlationId);

            return correlationId.FirstOrDefault() ?? httpContext.TraceIdentifier;
        }
    }
}
