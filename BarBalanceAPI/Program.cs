using BarBalanceAPI.Data;
using BarBalanceAPI.Models;
using Microsoft.EntityFrameworkCore;
using BarBalanceAPI.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/BarBalanceAPILogs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
try
{
    Log.Information("Starting BarBalanceAPI");

    var builder = WebApplication.CreateBuilder(args);

    builder.RegisterServices();

    var app = builder.Build();

    app.RegisterMiddlewares();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex,"Applicaion terminated unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}


