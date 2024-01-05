using BarBalanceAPI.Models;
using Serilog;

namespace BarBalanceAPI.Middleware
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionHandleMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke (HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExeption(ex, context);
            }
            
        }

        private async Task HandleExeption(Exception ex, HttpContext context)
        {
            Log.Error(ex, "Error happend!");

            if (ex is InvalidOperationException)
            {
                context.Response.StatusCode = 400;

                await context.Response.WriteAsJsonAsync(new ResponseModel
                {
                    Message = "Invalid operation",
                    StatusCode = 400,
                    Success = false
                });
            }
            else if (ex is ArgumentException) 
            {
                await context.Response.WriteAsync("Invalid Argument");
            }
            else
            {
                await context.Response.WriteAsync("Unknown error");
            }
        }

    }
    public static class ExceptionHandleMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandleMiddleware>();
        }
    }
}
