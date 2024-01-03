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

revenues.MapGet("/", GetAllReveues);
revenues.MapGet("/{id}", GetRevenue);
revenues.MapPost("/", CreateRevenue);
revenues.MapPut("/{id}", UpdateRevenue);
revenues.MapDelete("/{id}", DeleteRevenue);
static async Task<IResult> GetAllReveues(DataContext db)
{
    return TypedResults.Ok(await db.Revenues.Where(r => r.IsDelete == false)
                        .ToListAsync());
}
//revenues.MapGet("/", async (DataContext db) =>
//    await db.Revenues.Where(r => r.IsDelete == false)
//                        .ToListAsync());
static async Task<IResult> GetRevenue(int id, DataContext db)
{
    return await db.Revenues.Where(r => r.IsDelete == false).FirstOrDefaultAsync(r => r.ID == id)
     is Revenue revenue
         ? TypedResults.Ok(revenue)
         : TypedResults.NotFound();
}
//revenues.MapGet("/{id}", async (int id, DataContext db) =>
//    await db.Revenues.Where(r => r.IsDelete == false).FirstOrDefaultAsync(r => r.ID == id)
//    //await db.Revenues.FindAsync(id)
//    is Revenue revenue
//        ? Results.Ok(revenue)
//        : Results.NotFound());
static async Task<IResult> CreateRevenue(Revenue revenue, DataContext db)
{
    db.Revenues.Add(revenue);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/revenues/{revenue.ID}", revenue);
}
//revenues.MapPost("/", async (Revenue revenue, DataContext db) =>
//{
//    db.Revenues.Add(revenue);
//    await db.SaveChangesAsync();

//    return Results.Created($"/revenues/{revenue.ID}", revenue);
//});
static async Task<IResult> UpdateRevenue(int id, Revenue inputReveue, DataContext db)
{
    var revenue = await db.Revenues.Where(r => r.IsDelete == false).FirstOrDefaultAsync(r => r.ID == id);

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

    return TypedResults.NoContent();
}
//revenues.MapPut("/{id}", async (int id, Revenue inputReveue, DataContext db) =>
//{
//    var revenue = await db.Revenues.Where(r => r.IsDelete == false).FirstOrDefaultAsync(r => r.ID == id);

//    if (revenue is null) return Results.NotFound();

//    revenue.ShiftDate = inputReveue.ShiftDate;
//    revenue.CashOpening = inputReveue.CashOpening;
//    revenue.SafeOpening = inputReveue.SafeOpening;
//    revenue.CashReceived = inputReveue.CashReceived;
//    revenue.CashWithdrawn = inputReveue.CashWithdrawn;
//    revenue.CashClosing = inputReveue.CashClosing;
//    revenue.SafeClosing = inputReveue.SafeClosing;
//    revenue.CardPayments = inputReveue.CardPayments;
//    revenue.DailyReport = inputReveue.DailyReport;
//    revenue.InternalExpenditure = inputReveue.InternalExpenditure;
//    revenue.InvoicesWithoutFiscalization = inputReveue.InvoicesWithoutFiscalization;
//    revenue.CardTips = inputReveue.CardTips;
//    revenue.DailyRevenueTotal = inputReveue.DailyRevenueTotal;
//    revenue.DailyIncome = inputReveue.DailyIncome;

//    await db.SaveChangesAsync();

//    return Results.NoContent();
//});
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
//revenues.MapDelete("/{id}", async (int id, DataContext db) => {
//    if (await db.Revenues.Where(r => r.IsDelete == false).FirstOrDefaultAsync(r => r.ID == id)
//                        is Revenue revenue)
//    {        
//        revenue.IsDelete = true;

//        await db.SaveChangesAsync();

//        return Results.NoContent();
//    }

//    return Results.NotFound();

//});

app.Run();
