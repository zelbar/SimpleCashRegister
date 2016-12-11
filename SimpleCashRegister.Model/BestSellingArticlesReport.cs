using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    public class BestSellingArticlesReport
    {
        public BestSellingArticlesReport()
        {
            Date = DateTime.Now;
        }

        public IEnumerable<BestSellingArticleReportItem> Items { get; set; }
        public DateTime Date { get; set; }
    }
}
