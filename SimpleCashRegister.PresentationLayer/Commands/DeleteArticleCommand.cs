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
        public DeleteArticleCommand(ArticleController articleController) : base(articleController)
        {
        }

        public bool AdminOnly { get { return true; } }

        public string Description { get { return "Deletes an existing article."; } }

        public string Name { get { return "delete-article"; } }

        public void Execute(string[] args)
        {
            int id = Convert.ToInt32(args[1]);
            _articleController.DeleteArticle(id);
        }
    }
}
