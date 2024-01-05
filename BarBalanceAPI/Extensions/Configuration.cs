using BarBalanceAPI.Data;
using BarBalanceAPI.Middleware;
using Carter;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Runtime.CompilerServices;

namespace BarBalanceAPI.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog();
            builder.Services
                .AddEndpointsApiExplorer()
                .AddCarter()
                .AddDbContext<DataContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("BarBalanceAPIConnection"));
                });
        }
        public static void RegisterMiddlewares(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.MapCarter();
            app.UseExceptionHandleMiddleware();
        }
    }
}
