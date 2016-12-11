using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer.Commands.Article;
using SimpleCashRegister.Model.Factories;
using SimpleCashRegister.PresentationLayer.Views;

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
            var receiptFactory = new ReceiptFactory();
            var receipt = receiptFactory.Create(new List<Model.Item>());
            var view = new ReceiptView();

            var receiptCommands = new ReceiptItemCommands(_articleServices, receipt);
            char cmdChar;
            do
            {
                Console.WriteLine("Use + to add item, - to remove item, any other key to continue. ");
                cmdChar = Console.ReadLine()[0];

                if (cmdChar == '+')
                {
                    receiptCommands.AddItem();
                }
                else if (cmdChar == '-')
                {
                    receiptCommands.DeleteItem();
                }
                else
                {
                    Console.WriteLine("All items registered? (y/n) ");
                    cmdChar = Console.ReadLine()[0];

                    if (cmdChar == 'y')
                        break;
                }

                Console.WriteLine("\n" + view.Display(receipt));
            } while (true);

            Console.WriteLine("Issue receipt? Press i to issue or any key to cancel: ");
            cmdChar = Console.ReadLine()[0];

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
