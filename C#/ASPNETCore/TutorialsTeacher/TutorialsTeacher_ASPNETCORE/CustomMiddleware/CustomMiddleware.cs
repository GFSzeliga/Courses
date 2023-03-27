using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TutorialsTeacher_ASPNETCORE.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _ilogger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> ilogger)
        {
            _next = next;
            _ilogger = ilogger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _ilogger.LogInformation("MyMiddleware executing..");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
