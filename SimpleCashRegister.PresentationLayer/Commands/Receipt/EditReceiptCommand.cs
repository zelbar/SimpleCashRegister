using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;
using SimpleCashRegister.Exceptions;
using SimpleCashRegister.Model.Factories;
using SimpleCashRegister.PresentationLayer.Views;

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
            Console.WriteLine("Enter receipt id: ");
            var line = Console.ReadLine();
            var parser = new Parsers.ReceiptIdParser();
            var receiptId = parser.Parse(line);

            try
            {
                receiptId = parser.Parse(line);
            }
            catch (ParseException)
            {
                Console.Error.Write(">>> Couldn't parse receipt id.");
                return;
            }

            Model.Receipt receipt = default(Model.Receipt);
            try
            {
                receipt = _receiptServices.GetById(receiptId);
            }
            catch (EntityNotFoundException)
            {
                Console.Error.WriteLine(">>> Receipt with specified id wasn't found.");
                return;
            }

            var view = new ReceiptView();
            Console.WriteLine(view.Display(receipt));

            var receiptCommands = new ReceiptItemCommands(_articleServices, receipt, view);
            receiptCommands.Run();

            Console.WriteLine("Re-issue receipt? Press r to re-issue or any key to discard changes: ");
            char cmdChar;
            try
            {
                cmdChar = Console.ReadLine()[0];
            }
            catch (Exception)
            {
                cmdChar = 'x';
            }

            if (cmdChar == 'r')
            {
                try
                {
                    _receiptServices.EditReceipt(receipt);
                    Console.WriteLine(view.Display(receipt));
                }
                catch (EnptyReceiptIssuingException)
                {
                    Console.Error.WriteLine("Couldn't re-issue as an empty receipt.");
                }
            }
            else
            {
                Console.WriteLine("Receipt re-issuing cancelled.");
            }
        }
    }
}
