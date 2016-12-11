using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Exceptions;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer.Parsers;

namespace SimpleCashRegister.PresentationLayer.Commands.Article
{
    public class EditArticleCommand : ArticleCommand, ICommand
    {
        public EditArticleCommand(ArticleServices articleServices) : base(articleServices) { }
        bool ICommand.AdminOnly { get { return true; } }
        string ICommand.Name { get { return "edit-article"; } }
        string ICommand.Description { get { return "Edits an existing article."; } }

        protected override void ReadLine()
        {
            Console.WriteLine("\nEDIT EXISTING ARTICLE");
            Console.WriteLine("Enter article details in this format: id;q(antity)|m(ass);name;price;vatrate");
            Console.WriteLine("eg. 10;q;Vodka 0.3l;42,36;0,25");
            base.ReadLine();
        }

        void ICommand.Execute()
        {
            var parser = new ArticleParser();
            Model.Article article = null;
            try
            {
                article = parser.Parse(_line);
            }
            catch(ParseException)
            {
                Console.WriteLine("Invalid input format.");
            }

            try
            {
                _articleServices.EditArticle(article);
            }
            catch(Exception)
            {
                Console.Error.WriteLine("Article with specified id could not be found.");
            }
            Console.WriteLine();
        }
    }
}
