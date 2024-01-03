using System.ComponentModel.DataAnnotations.Schema;

namespace BarBalanceAPI.Models
{
    public class RevenueDTO
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

        public decimal DailyRevenueTotal { get; set; }

        public decimal DailyIncome { get; set; }

        public RevenueDTO() { }
        public RevenueDTO(Revenue revenue) =>
        (
            ID,
            ShiftDate,
            CashOpening,
            SafeOpening,
            CashReceived,
            CashWithdrawn,
            CashClosing,
            SafeClosing,
            CardPayments,
            DailyReport,
            InternalExpenditure,
            InvoicesWithoutFiscalization,
            CardTips,
            DailyRevenueTotal,
            DailyIncome
        ) = (
            revenue.ID,
            revenue.ShiftDate,
            revenue.CashOpening,
            revenue.SafeOpening,
            revenue.CashReceived,
            revenue.CashWithdrawn,
            revenue.CashClosing,
            revenue.SafeClosing,
            revenue.CardPayments,
            revenue.DailyReport,
            revenue.InternalExpenditure,
            revenue.InvoicesWithoutFiscalization,
            revenue.CardTips,
            revenue.DailyRevenueTotal,
            revenue.DailyIncome
       );
    }
}