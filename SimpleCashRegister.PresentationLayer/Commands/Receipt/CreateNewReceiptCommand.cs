using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer.Commands.Article;
using SimpleCashRegister.Model.Factories;
using SimpleCashRegister.PresentationLayer.Views;
using SimpleCashRegister.Exceptions;

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

            var receiptCommands = new ReceiptItemCommands(_articleServices, receipt, view);
            receiptCommands.Run();

            Console.WriteLine("Issue receipt? Press i to issue or any key to cancel: ");
            char cmdChar;
            try
            {
                cmdChar = Console.ReadLine()[0];
            }
            catch (Exception)
            {
                cmdChar = 'x';
            }

            if (cmdChar == 'i')
            {
                try
                {
                    _receiptServices.IssueReceipt(receipt);
                    Console.WriteLine(view.Display(receipt));
                    Console.WriteLine("Receipt successfully issued.");
                }
                catch (EnptyReceiptIssuingException)
                {
                    Console.Error.WriteLine("Couldn't issue an empty receipt.");
                }
            }
            else
            {
                Console.WriteLine("Receipt cancelled.");
            }
        }
    }
}
