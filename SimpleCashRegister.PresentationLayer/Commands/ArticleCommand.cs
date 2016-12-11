using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Controllers;

namespace SimpleCashRegister.PresentationLayer.Commands
{
    public class ArticleCommand
    {
        public ArticleCommand(ArticlesController articleController)
        {
            _articleController = articleController;
            ReadLine();
        }

        protected readonly ArticlesController _articleController;
        protected string _line;

        protected virtual void ReadLine()
        {
            _line = Console.ReadLine();
        }
    }
}
