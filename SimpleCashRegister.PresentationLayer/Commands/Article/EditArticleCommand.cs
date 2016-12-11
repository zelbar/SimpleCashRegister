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

        void ICommand.Execute(string[] args)
        {
            Console.WriteLine("Enter article details in this format: id;q(antity)|m(ass);name;price;vatrate");
            Console.WriteLine("eg. 10;q;Vodka 0.3l;42,36;0,25");

            var line = Console.ReadLine();
            var parser = new ArticleParser();
            Model.Article article = null;
            try
            {
                article = parser.Parse(line);
            }
            catch(ParseException)
            {
                Console.WriteLine(">>> Invalid input format.");
                return;
            }

            try
            {
                _articleServices.EditArticle(article);
                Console.WriteLine("Article successfully edited.");
            }
            catch (EntityNotFoundException)
            {
                Console.Error.WriteLine(">>> " + ArticleNotFoundMessage);
            }
        }
    }
}
