using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer.Commands.Article;

namespace SimpleCashRegister.PresentationLayer.Commands.Receipt
{
    public class CreateNewReceiptCommand : ReceiptCommand, ICommand
    {
        public CreateNewReceiptCommand(ArticleServices articleServices, ReceiptServices receiptServices) 
            : base(articleServices, receiptServices)
        {
        }

        public bool AdminOnly { get { return false; } }

        public string Description { get { return "Creates a new receipt to add items in it."; } }

        public string Name { get { return "new-receipt"; } }

        public void Execute(string [] args)
        {
            var receipt = new Model.Receipt();
            var receiptCommands = new ReceiptItemCommands(_articleServices, receipt);

            char cmdChar;
            do
            {
                cmdChar = Console.ReadKey().ToString()[0];
                if (cmdChar == '+')
                {
                    receiptCommands.AddItem();
                }
                else if (cmdChar == '-')
                {
                    receiptCommands.DeleteItem();
                }

            } while (cmdChar == '+' || cmdChar == '-');

            Console.WriteLine("Issue receipt? Press i to issue or any key to cancel: ");
            cmdChar = Console.ReadKey().ToString().ToLower()[0];

            if (cmdChar == 'i')
            {
                receipt.DateTimeIssued = DateTime.Now;
                _receiptServices.AddNewReceipt(receipt);
            }
            else
            {
                Console.WriteLine("Receipt cancelled.");
            }

        }
    }
}
