using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BarBalanceAPI.Models
{
    public class Revenue
    {
        public int ID { get; set; }
        public DateOnly ShiftDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CashOpening { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SafeOpening { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CashReceived { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CashWithdrawn { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CashClosing { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SafeClosing { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CardPayments { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DailyReport { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal InternalExpenditure { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal InvoicesWithoutFiscalization { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CardTips { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DailyRevenueTotal { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DailyIncome { get; set; }
    }
}
