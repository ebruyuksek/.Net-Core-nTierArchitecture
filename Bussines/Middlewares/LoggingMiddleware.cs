using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Bussines.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            finally
            {
                var logText = new StringBuilder()
                    .Append(httpContext.Request?.Method)
                    .Append(" ").Append(httpContext.Request?.Path.Value)
                    .Append(" => ").AppendLine(httpContext.Response?.StatusCode.ToString())
                    .ToString();
                File.AppendAllText("log.txt", logText);
            }
        }
    }

    public static class LoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }

}
