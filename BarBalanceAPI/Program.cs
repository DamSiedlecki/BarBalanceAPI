using BarBalanceAPI.Data;
using BarBalanceAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BarBalanceAPIConnection"));
});
var app = builder.Build();

app.MapGet("/", () => "Bar Balance minimal Api.");

app.MapGet("/revenues", async (DataContext db) =>
    await db.Revenues.ToListAsync());

app.MapGet("revenues/{id}", async (int id, DataContext db) =>
    await db.Revenues.FindAsync(id)
    is Revenue revenue
        ? Results.Ok(revenue)
        : Results.NotFound());

app.Run();
