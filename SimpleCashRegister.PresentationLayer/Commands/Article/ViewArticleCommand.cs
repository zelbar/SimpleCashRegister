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
    public class ViewArticleCommand : ArticleCommand, ICommand
    {
        public ViewArticleCommand(ArticleServices articleServices) : base(articleServices) { }
        bool ICommand.AdminOnly { get { return true; } }
        string ICommand.Name { get { return "view-article"; } }
        string ICommand.Description { get { return "Edits an existing article."; } }

        void ICommand.Execute(string[] args)
        {
            Console.WriteLine("Enter article id: ");

            var line = Console.ReadLine();
            var parser = new ArticleIdParser();
            long id;
            try
            {
                id = parser.Parse(line);
            }
            catch(ParseException)
            {
                Console.WriteLine("Invalid input format.");
                return;
            }

            Model.Article article = default(Model.Article);
            try
            {
                article = _articleServices.GetById(id);
            }
            catch(EntityNotFoundException)
            {
                Console.Error.WriteLine(">>> " + ArticleNotFoundMessage);
                return;
            }

            var view = new Views.ArticleView();
            Console.WriteLine(view.Display(article));
        }
    }
}
