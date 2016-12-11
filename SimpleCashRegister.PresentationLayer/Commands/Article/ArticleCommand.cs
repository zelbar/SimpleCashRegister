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
        }

        protected readonly ArticleServices _articleServices;
    }
}
