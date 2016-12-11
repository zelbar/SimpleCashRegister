using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Model;

namespace SimpleCashRegister.PresentationLayer.Views
{
    class BestSellingArticlesReportView : IView<BestSellingArticlesReport>
    {
        public string Display(BestSellingArticlesReport report)
        {
            var sb = new StringBuilder();
            foreach (var item in report.Items)
            {
                sb.AppendFormat("{0}: {1} ({C}), Total revenue {2}",
                    item.Article.Id, item.Article.Name, item.Article.Price, item.TotalRevenue);
            }
            var rv = sb.ToString();
            return rv;
        }
    }
}
