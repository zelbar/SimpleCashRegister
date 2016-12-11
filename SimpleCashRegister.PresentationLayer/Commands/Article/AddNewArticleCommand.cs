using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer.Parsers;
using SimpleCashRegister.Model;
using SimpleCashRegister.Exceptions;

namespace SimpleCashRegister.PresentationLayer.Commands.Article
{
    public class AddNewArticleCommand : ArticleCommand, ICommand
    {
        public AddNewArticleCommand(ArticleServices articleServices) : base(articleServices) { }
        bool ICommand.AdminOnly { get { return true; } }
        string ICommand.Name { get { return "add-article"; } }
        string ICommand.Description { get { return "Add a new article."; } }

        protected override void ReadLine()
        {
            Console.WriteLine("\nADD NEW ARTICLE");
            Console.WriteLine("Enter article details in this format: id;q(antity)|m(ass);name;price;vatrate");
            Console.WriteLine("eg. 10;q;Vodka 0.3l;42,36;0,25");
            base.ReadLine();
        }

        void ICommand.Execute()
        {
            var parser = new ArticleParser();
            Model.Article article = default(Model.Article);
            try
            {
                article = parser.Parse(_line);
            }
            catch(ParseException)
            {
                Console.Error.WriteLine("Invalid input format.");
                return;
            }

            _articleServices.AddNewArticle(article);
            Console.WriteLine();
        }
    }
}
