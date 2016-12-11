using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;
using SimpleCashRegister.Exceptions;

namespace SimpleCashRegister.PresentationLayer.Commands.Article
{
    public class DeleteArticleCommand : ArticleCommand, ICommand
    {
        public DeleteArticleCommand(ArticleServices articleServices) : base(articleServices)
        {
        }

        public bool AdminOnly { get { return true; } }

        public string Description { get { return "Deletes an existing article."; } }

        public string Name { get { return "delete-article"; } }

        public void Execute(string[] args)
        {
            Console.WriteLine("Enter article id: ");

            var line = Console.ReadLine();
            int id = default(int);
            try
            {
                id = Convert.ToInt32(line);
            }
            catch (FormatException)
            {
                Console.WriteLine(">>> Invalid input format.");
                return;
            }
            try
            {
                _articleServices.DeleteArticle(id);
                Console.WriteLine("Article successfully deleted.");
            }
            catch (EntityNotFoundException)
            {
                Console.Error.WriteLine("Article with given id not found.");
                return;
            }
        }
    }
}
