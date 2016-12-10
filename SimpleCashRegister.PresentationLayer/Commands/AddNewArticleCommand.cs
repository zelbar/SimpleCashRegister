using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Controllers;

namespace SimpleCashRegister.PresentationLayer.Commands
{
    public class AddNewArticleCommand : ArticleCommand//, ICommand
    {
        public AddNewArticleCommand(ArticleController articleController) : base(articleController) { }
        bool AdminOnly { get { return true; } }

        string Name { get { return "add-article"; } }
        string Description { get { return "Add a new article."; } }

        void Execute(string[] args)
        {
            //_articleController.AddNewArticle(args);
        }
    }
}
