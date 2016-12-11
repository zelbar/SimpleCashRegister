using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;

namespace SimpleCashRegister.PresentationLayer.Commands.Receipt
{
    abstract public class ReceiptCommand
    {
        public ReceiptCommand(ArticleServices articleServices, ReceiptServices receiptServices)
        {
            _articleServices = articleServices;
            _receiptServices = receiptServices;
        }

        protected readonly ArticleServices _articleServices;
        protected readonly ReceiptServices _receiptServices;
        private ReceiptServices receiptServices;
    }
}
