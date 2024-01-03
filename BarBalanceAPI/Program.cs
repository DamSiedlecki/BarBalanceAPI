using Azure.Identity;
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

revenues.MapGet("/", GetAllRevenues);
revenues.MapGet("/{id}", GetRevenue);
revenues.MapPost("/", CreateRevenue);
revenues.MapPut("/{id}", UpdateRevenue);
revenues.MapDelete("/{id}", DeleteRevenue);

static async Task<IResult> GetAllRevenues(DataContext db)
{
   return TypedResults.Ok(await db.Revenues.Select(r => new RevenueDTO(r)).ToArrayAsync());
}

static async Task<IResult> GetRevenue(int id, DataContext db)
{
    return await db.Revenues.FindAsync(id)
        is Revenue revenue
            ? TypedResults.Ok(new RevenueDTO(revenue))
            : TypedResults.NotFound();
}

static async Task<IResult> CreateRevenue(RevenueDTO revenueDTO, DataContext db)
{
    var revenue = new Revenue
    {
        ShiftDate = revenueDTO.ShiftDate,
        CashOpening = revenueDTO.CashOpening,
        SafeOpening = revenueDTO.SafeOpening,
        CashReceived = revenueDTO.CashReceived,
        CashWithdrawn = revenueDTO.CashWithdrawn,
        CashClosing = revenueDTO.CashClosing,
        SafeClosing = revenueDTO.SafeClosing,
        CardPayments = revenueDTO.CardPayments,
        DailyReport = revenueDTO.DailyReport,
        InternalExpenditure = revenueDTO.InternalExpenditure,
        InvoicesWithoutFiscalization = revenueDTO.InvoicesWithoutFiscalization,
        CardTips = revenueDTO.CardTips,
        DailyRevenueTotal = revenueDTO.DailyRevenueTotal,
        DailyIncome = revenueDTO.DailyIncome
};

    db.Revenues.Add(revenue);
    await db.SaveChangesAsync();

    revenueDTO = new RevenueDTO(revenue);

    return TypedResults.Created($"/todoitems/{revenue.ID}", revenueDTO);
}

static async Task<IResult> UpdateRevenue(int id, RevenueDTO revenueDTO, DataContext db)
{
    var revenue = await db.Revenues.FindAsync(id);

    if (revenue is null) return TypedResults.NotFound();

    revenue.ShiftDate = revenueDTO.ShiftDate;
    revenue.CashOpening = revenueDTO.CashOpening;
    revenue.SafeOpening = revenueDTO.SafeOpening;
    revenue.CashReceived = revenueDTO.CashReceived;
    revenue.CashWithdrawn = revenueDTO.CashWithdrawn;
    revenue.CashClosing = revenueDTO.CashClosing;
    revenue.SafeClosing = revenueDTO.SafeClosing;
    revenue.CardPayments = revenueDTO.CardPayments;
    revenue.DailyReport = revenueDTO.DailyReport;
    revenue.InternalExpenditure = revenueDTO.InternalExpenditure;
    revenue.InvoicesWithoutFiscalization = revenueDTO.InvoicesWithoutFiscalization;
    revenue.CardTips = revenueDTO.CardTips;
    revenue.DailyRevenueTotal = revenueDTO.DailyRevenueTotal;
    revenue.DailyIncome = revenueDTO.DailyIncome;

    await db.SaveChangesAsync();

    return Results.NoContent();
}

static async Task<IResult> DeleteRevenue(int id, DataContext db)
{
    if(await db.Revenues.FindAsync(id) is Revenue revenue)
    {
        db.Revenues.Remove(revenue);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}

app.Run();
