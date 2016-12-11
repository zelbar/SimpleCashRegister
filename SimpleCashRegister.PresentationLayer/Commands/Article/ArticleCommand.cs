using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;

namespace SimpleCashRegister.PresentationLayer.Commands.Article
{
    public abstract class ArticleCommand
    {
        public ArticleCommand(ArticleServices articleServices)
        {
            _articleServices = articleServices;
            ReadLine();
        }

        protected readonly ArticleServices _articleServices;
        protected string _line;

        protected virtual void ReadLine()
        {
            _line = Console.ReadLine();
        }
    }
}
