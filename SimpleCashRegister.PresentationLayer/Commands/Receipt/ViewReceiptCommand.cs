using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer.Parsers;
using SimpleCashRegister.Exceptions;

namespace SimpleCashRegister.PresentationLayer.Commands.Receipt
{
    public class ViewReceiptCommand : ReceiptCommand, ICommand
    {
        public ViewReceiptCommand(ArticleServices articleServices, ReceiptServices receiptServices) 
            : base(articleServices, receiptServices)
        {
        }

        public bool AdminOnly { get { return false; } }

        public string Description { get { return "Displays all receipt details with articles."; } }

        public string Name { get { return "view-receipt"; } }

        public void Execute(string[] args)
        {
            Console.WriteLine("Enter receipt id: ");
            var line = Console.ReadLine();
            var parser = new ReceiptIdParser();
            Guid id;
            try
            {
                id = parser.Parse(line);
            }
            catch (ParseException)
            {
                Console.Error.WriteLine("Couldn't parse receipt id.");
                return;
            }

            Model.Receipt receipt = default(Model.Receipt);
            try
            {
                receipt = _receiptServices.GetById(id);
            }
            catch(EntityNotFoundException)
            {
                Console.Error.WriteLine("Receipt with specified id could't be found.");
                return;
            }

            var receiptView = new Views.ReceiptView();
            Console.WriteLine(receiptView.Display(receipt));
        }
    }
}
