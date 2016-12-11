using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer.Parsers;

namespace SimpleCashRegister.PresentationLayer.Commands.Receipt
{
    class DeleteReceiptCommand : ReceiptCommand, ICommand
    {
        public DeleteReceiptCommand(ArticleServices articleServices, ReceiptServices receiptServices) 
            : base(articleServices, receiptServices)
        {
        }

        public bool AdminOnly { get { return true; } }

        public string Description { get { return "Deletes an existing receipt by id."; } }

        public string Name { get { return "delete-receipt"; } }

        public void Execute()
        {
            Console.WriteLine("Enter receipt id: ");
            var line = Console.ReadLine();
            var parser = new Parsers.ReceiptIdParser();
            var receiptId = parser.Parse(line);

            Model.Receipt receipt = default(Model.Receipt);
            try
            {
                _receiptServices.DeleteReceipt(receipt.Id);
            }
            catch(EntryPointNotFoundException)
            {
                Console.Error.WriteLine("Receipt with specified id wasn't found.");
                return;
            }
        }
    }
}
