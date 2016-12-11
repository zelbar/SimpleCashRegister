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
        protected static readonly string ArticleAlreadyExistsMessage = "Article with specified id already exists";
        protected static readonly string ArticleNotFoundMessage = "Article with specified id not found.";

        public ArticleCommand(ArticleServices articleServices)
        {
            _articleServices = articleServices;
        }

        protected readonly ArticleServices _articleServices;
    }
}
