using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    public class BestSellingArticleReportItem
    {
        public BestSellingArticleReportItem(Article article, decimal totalRevenue)
        {
            Article = article;
            TotalRevenue = totalRevenue;
        }
        public Article Article { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
