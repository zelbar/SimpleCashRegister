using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model.Factories
{
    public class BestSellingArticlesReportFactory
    {
        public BestSellingArticlesReport Create()
        {
            var bestSellingArticlesReport = new BestSellingArticlesReport()
            {
                Date = DateTime.Now
            };
            return bestSellingArticlesReport;
        }
    }
}
