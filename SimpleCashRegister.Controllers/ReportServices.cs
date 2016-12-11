using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DataAccessLayer.Repositories;

namespace SimpleCashRegister.Services
{
    public class ReportServices
    {
        public ReportServices(ArticleRepository articleRepository, ReceiptRepository receiptRepository)
        {
            _articleRepository = articleRepository;
            _receiptRepository = receiptRepository;
        }

        private readonly ArticleRepository _articleRepository;
        private readonly ReceiptRepository _receiptRepository;

        public void Daily(DateTime dt)
        {
            //
        }

        public void ByArticle()
        {

        }
    }
}
