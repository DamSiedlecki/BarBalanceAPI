using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BarBalanceAPI.Models
{
    public class Revenue
    {
        public int ID { get; set; }
        public DateOnly ShiftDate { get; set; }
        public decimal CashOpening { get; set; }
        public decimal SafeOpening { get; set; }
        public decimal CashReceived { get; set; }
        public decimal CashWithdrawn { get; set; }
        public decimal CashClosing { get; set; }
        public decimal SafeClosing { get; set; }
        public decimal CardPayments { get; set; }
        public decimal DailyReport { get; set; }
        public decimal InternalExpenditure { get; set; }
        public decimal InvoicesWithoutFiscalization { get; set; }
        public decimal CardTips { get; set; }

        // Additional calculations
        public decimal DailyRevenueTotal => InternalExpenditure + DailyReport;
        public decimal DailyIncome => DailyRevenueTotal + InvoicesWithoutFiscalization;
    }
}
