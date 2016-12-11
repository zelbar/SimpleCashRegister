using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer.Views;

namespace SimpleCashRegister.PresentationLayer.Commands.Report
{
    public class BestSellingArticlesReportCommand : ReportCommand, ICommand
    {
        public BestSellingArticlesReportCommand(ReportServices reportServices) : base(reportServices)
        {
        }

        public bool AdminOnly { get { return false; } }

        public string Description { get { return "List the first n best-selling articles by total revenue."; } }

        public string Name { get { return "bestselling-report"; } }

        public void Execute(string[] args)
        {
            Console.Write("How many articles to list? ");
            int n;
            var line = Console.ReadLine();
            if (int.TryParse(line, out n))
            {
                var bestSellingArticles = _reportServices.BestSellingArticlesReport(n);
                var view = new BestSellingArticlesReportView();
                Console.WriteLine(view.Display(bestSellingArticles));
            }
            else
            {
                Console.Error.WriteLine(">>> Couldn't parse the number.");
            }
        }
    }
}
