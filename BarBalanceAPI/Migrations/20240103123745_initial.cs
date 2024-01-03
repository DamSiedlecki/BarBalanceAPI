using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarBalanceAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CashOpening = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SafeOpening = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashReceived = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashWithdrawn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashClosing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SafeClosing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CardPayments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyReport = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InternalExpenditure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoicesWithoutFiscalization = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CardTips = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyRevenueTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revenues");
        }
    }
}
