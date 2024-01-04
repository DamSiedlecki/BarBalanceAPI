using BarBalanceAPI.Data;
using BarBalanceAPI.Models;
using Microsoft.EntityFrameworkCore;
using BarBalanceAPI.Extensions;
using BarBalanceAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();

app.RegisterRevenuesEndoints();

app.Run();
