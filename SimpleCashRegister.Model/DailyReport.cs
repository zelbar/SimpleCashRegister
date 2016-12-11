using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    public class DailyReport
    {
        public DateTime Date { get; set; }
        public int NumberOfReceipt { get; set; }
        public decimal TotalPayments { get; set; }
        public decimal TotalPaymentsIncludingVat { get; set; }
        public decimal TotalVat { get { return TotalPaymentsIncludingVat - TotalPayments; } }
        public IEnumerable<Receipt> Receipts { get; set; }
    }
}
