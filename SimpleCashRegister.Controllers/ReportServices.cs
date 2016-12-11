using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DAL.Repositories;

namespace SimpleCashRegister.Services
{
    public class ReportServices
    {
        public ReportServices(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        private readonly ArticleRepository _articleRepository;

        public void Daily(DateTime dt)
        {
            //
        }

        public void ByArticle()
        {

        }
    }
}
