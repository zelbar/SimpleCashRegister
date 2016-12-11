using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Controllers;

namespace SimpleCashRegister.PresentationLayer.Commands
{
    class DeleteArticleCommand : ArticleCommand, ICommand
    {
        public DeleteArticleCommand(ArticlesController articleController) : base(articleController)
        {
        }

        public bool AdminOnly { get { return true; } }

        public string Description { get { return "Deletes an existing article."; } }

        public string Name { get { return "delete-article"; } }

        public void Execute()
        {
            int id = default(int);
            try
            {
                id = Convert.ToInt32(_line);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
            }
            _articleController.DeleteArticle(id);
            Console.WriteLine();
        }
    }
}
