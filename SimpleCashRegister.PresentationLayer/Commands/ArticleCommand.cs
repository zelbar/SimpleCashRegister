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
        public ArticleCommand(ArticleController articleController)
        {
            _articleController = articleController;
        }

        protected readonly ArticleController _articleController;
    }
}
