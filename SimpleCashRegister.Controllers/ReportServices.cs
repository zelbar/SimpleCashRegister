using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DataAccessLayer.Repositories;
using SimpleCashRegister.Model;
using SimpleCashRegister.Model.Factories;

namespace SimpleCashRegister.Services
{
    public class ReportServices
    {
        public ReportServices(ArticleRepository articleRepository, ReceiptRepository receiptRepository)
        {
            _articleRepository = articleRepository;
            _receiptRepository = receiptRepository;
        }

        private readonly ArticleRepository _articleRepository;
        private readonly ReceiptRepository _receiptRepository;

        IEnumerable<Item> ExtractItemsFromReceipts(IEnumerable<Receipt> receipts)
        {
            var rv = new List<Item>();
            foreach (var itemList in receipts.Select(x => x.Items))
            {
                foreach (var item in itemList)
                {
                    rv.Add(item);
                }
            }
            return rv;
        }

        void GetDailyReportData(DateTime dt, out IEnumerable<Receipt> receipts, out IEnumerable<Item> items, out IEnumerable<Article> articles)
        {
            receipts = _receiptRepository.GetAll()
                .Where(x => x.DateTimeIssued.Date == dt.Date);
            items = ExtractItemsFromReceipts(receipts);
            articles = items.Select(x => x.Article).Distinct();
        }

        public DailyReport DailyReport(DateTime dt)
        {
            IEnumerable<Receipt> receipts;
            IEnumerable<Item> items;
            IEnumerable<Article> articles;

            GetDailyReportData(dt, out receipts, out items, out articles);

            var factory = new DailyReportFactory();
            var dailyReport = factory.Create(dt, receipts, items, articles);
            return dailyReport;
        }

        IEnumerable<BestSellingArticleReportItem> GetBestSellingArticles(int limit)
        {
            var receipts = _receiptRepository.GetAll();
            var items = ExtractItemsFromReceipts(receipts);
            var bestSellingArticles = items.GroupBy(x => x.Article)
                .OrderByDescending(x => x.Sum(y => y.GetCost())).Take(limit);

            return bestSellingArticles.Select(
                x => new BestSellingArticleReportItem(x.Key, x.Sum(y => y.GetCost()))
                );
        }

        public BestSellingArticlesReport BestSellingArticlesReport(int limit)
        {
            var bestSellingArticlesReport = new BestSellingArticlesReport()
            {
                Items = GetBestSellingArticles(limit)
            };
            return bestSellingArticlesReport;
        }
    }
}
