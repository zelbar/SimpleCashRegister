using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;

namespace SimpleCashRegister.PresentationLayer.Commands.Receipt
{
    public class EditReceiptCommand : ReceiptCommand, ICommand
    {
        public EditReceiptCommand(ArticleServices articleServices, ReceiptServices receiptServices) : 
            base(articleServices, receiptServices)
        {
        }

        public bool AdminOnly { get { return true; } }

        public string Description { get { return "Edit items of existing receipts and re-issue them."; } }

        public string Name { get { return "edit-receipt"; } }

        public void Execute(string[] args)
        {

        }
    }
}
