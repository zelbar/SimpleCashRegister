using SimpleCashRegister.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Views
{
    class DailyReportView : IView<DailyReport>
    {
        public string Display(DailyReport dailyReport)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("DAILY REPORT " + dailyReport.Date.Date);
            sb.AppendFormat("\nNumber of Receipts: {0}\nTotal Payments: {1}\nTotal Payments Including VAT: {2}\n",
                dailyReport.NumberOfReceipt, dailyReport.TotalPayments, dailyReport.TotalPaymentsIncludingVat);

            foreach(var item in dailyReport.Receipts)
            {
                sb.AppendFormat("{0}: {1} Articles, Total: {2}\n", 
                    item.DateTimeIssued.TimeOfDay, item.Items.Count, item.TotalCost.ToString("C"));
            }

            var rv = sb.ToString();
            return rv;
        }
    }
}
