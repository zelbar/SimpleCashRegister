using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Controllers;
using SimpleCashRegister.PresentationLayer.Views;

namespace SimpleCashRegister.PresentationLayer.Commands
{
    public class ListAllArticles : ArticleCommand, ICommand
    {
        public ListAllArticles(ArticlesController articleController) : base(articleController) { }
        bool ICommand.AdminOnly { get { return true; } }

        string ICommand.Name { get { return "list-articles"; } }
        string ICommand.Description { get { return "List all articles."; } }

        void ICommand.Execute()
        {
            var view = new ArticleView();
            var articles = _articleController.GetAllArticles();

            Console.WriteLine("\nLISTING ALL ARTICLES");
            foreach (var article in articles)
            {
                Console.WriteLine(view.Display(article));
            }
            Console.WriteLine();
        }
    }
}
