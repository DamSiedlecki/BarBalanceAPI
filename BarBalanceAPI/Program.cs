using BarBalanceAPI.Data;
using BarBalanceAPI.Models;
using BarBalanceAPI.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BarBalanceAPIConnection"));
});
var app = builder.Build();

var revenues = app.MapGroup("/revenues");

revenues.MapGet("/", GetAllReveues);
revenues.MapGet("/{id}", GetRevenue);
revenues.MapPost("/", CreateRevenue);
revenues.MapPut("/{id}", UpdateRevenue);
revenues.MapDelete("/{id}", DeleteRevenue);
static async Task<IResult> GetAllReveues(DataContext db)
{
    return TypedResults.Ok(await db.Revenues.Where(r => r.IsDelete == false)
                        .Select(r => new RevenueDTO(r)).ToArrayAsync());
}

static async Task<IResult> GetRevenue(int id, DataContext db)
{
    return await db.Revenues.Where(r => r.IsDelete == false).FirstOrDefaultAsync(r => r.ID == id)
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


    return TypedResults.Created($"/revenues/{revenue.ID}", revenueDTO);
}

static async Task<IResult> UpdateRevenue(int id, RevenueDTO reveueDTO, DataContext db)
{
    var revenue = await db.Revenues.Where(r => r.IsDelete == false).FirstOrDefaultAsync(r => r.ID == id);

    if (revenue is null) return Results.NotFound();

    revenue.ShiftDate = reveueDTO.ShiftDate;
    revenue.CashOpening = reveueDTO.CashOpening;
    revenue.SafeOpening = reveueDTO.SafeOpening;
    revenue.CashReceived = reveueDTO.CashReceived;
    revenue.CashWithdrawn = reveueDTO.CashWithdrawn;
    revenue.CashClosing = reveueDTO.CashClosing;
    revenue.SafeClosing = reveueDTO.SafeClosing;
    revenue.CardPayments = reveueDTO.CardPayments;
    revenue.DailyReport = reveueDTO.DailyReport;
    revenue.InternalExpenditure = reveueDTO.InternalExpenditure;
    revenue.InvoicesWithoutFiscalization = reveueDTO.InvoicesWithoutFiscalization;
    revenue.CardTips = reveueDTO.CardTips;
    revenue.DailyRevenueTotal = reveueDTO.DailyRevenueTotal;
    revenue.DailyIncome = reveueDTO.DailyIncome;

    await db.SaveChangesAsync();

    return TypedResults.NoContent();
}

static async Task<IResult> DeleteRevenue(int id, DataContext db)
{
    if (await db.Revenues.Where(r => r.IsDelete == false).FirstOrDefaultAsync(r => r.ID == id)
                        is Revenue revenue)
    {
        revenue.IsDelete = true;

        await db.SaveChangesAsync();

        return Results.NoContent();
    }

    return TypedResults.NotFound();
}

app.Run();
