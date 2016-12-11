using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model.Factories
{
    public class DailyReportFactory
    {
        public DailyReport Create(DateTime date, IEnumerable<Receipt> receipts,
        IEnumerable<Item> items, IEnumerable<Article> articles)
        {
            var dailyReport = new DailyReport()
            {
                Date = date,
                NumberOfReceipt = receipts.Count(),
                TotalPayments = receipts
                                .Sum(x => x.Items.Sum(y => y.GetCost())),
                TotalPaymentsIncludingVat = receipts
                    .Sum(x => x.Items.Sum(y => y.Article.PriceIncludingVat * y.GetUnits())),
                Receipts = receipts
            };

            return dailyReport;
        }
    }
}
