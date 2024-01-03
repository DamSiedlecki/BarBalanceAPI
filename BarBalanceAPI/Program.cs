using BarBalanceAPI.Data;
using BarBalanceAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BarBalanceAPIConnection"));
});
var app = builder.Build();

var revenues = app.MapGroup("/revenues");

revenues.MapGet("/", async (DataContext db) =>
    await db.Revenues.ToListAsync());

revenues.MapGet("/{id}", async (int id, DataContext db) =>
    await db.Revenues.FindAsync(id)
    is Revenue revenue
        ? Results.Ok(revenue)
        : Results.NotFound());

revenues.MapPost("/", async (Revenue revenue, DataContext db) =>
{
    db.Revenues.Add(revenue);
    await db.SaveChangesAsync();

    return Results.Created($"/revenues/{revenue.ID}", revenue);
});

revenues.MapPut("/{id}", async (int id, Revenue inputReveue, DataContext db) =>
{
    var revenue = await db.Revenues.FindAsync(id);

    if (revenue is null) return Results.NotFound();

    revenue.ShiftDate = inputReveue.ShiftDate;
    revenue.CashOpening = inputReveue.CashOpening;
    revenue.SafeOpening = inputReveue.SafeOpening;
    revenue.CashReceived = inputReveue.CashReceived;
    revenue.CashWithdrawn = inputReveue.CashWithdrawn;
    revenue.CashClosing = inputReveue.CashClosing;
    revenue.SafeClosing = inputReveue.SafeClosing;
    revenue.CardPayments = inputReveue.CardPayments;
    revenue.DailyReport = inputReveue.DailyReport;
    revenue.InternalExpenditure = inputReveue.InternalExpenditure;
    revenue.InvoicesWithoutFiscalization = inputReveue.InvoicesWithoutFiscalization;
    revenue.CardTips = inputReveue.CardTips;
    revenue.DailyRevenueTotal = inputReveue.DailyRevenueTotal;
    revenue.DailyIncome = inputReveue.DailyIncome;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

revenues.MapDelete("/{id}", async (int id, DataContext db) => {
    if (await db.Revenues.FindAsync(id) is Revenue revenue)
    {
        db.Revenues.Remove(revenue);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();

});

app.Run();
