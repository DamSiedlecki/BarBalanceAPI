using BarBalanceAPI.Data;
using BarBalanceAPI.Models;
using Microsoft.EntityFrameworkCore;
using BarBalanceAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();

app.Run();
