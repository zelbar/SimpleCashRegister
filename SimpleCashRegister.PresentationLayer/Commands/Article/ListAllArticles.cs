using System;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer.Views;

namespace SimpleCashRegister.PresentationLayer.Commands.Article
{
    public class ListAllArticles : ArticleCommand, ICommand
    {
        public ListAllArticles(ArticleServices articleServices) : base(articleServices)
        {
        }

        public bool AdminOnly { get { return false; } }

        public string Description { get { return "Lists all the articles."; } }

        public string Name { get { return "list-articles"; } }

        public void Execute(string[] args)
        {
            var articleView = new ArticleView();
            foreach (var article in _articleServices.GetAllArticles())
            {
                Console.WriteLine(articleView.Display(article));
            }
        }
    }
}
