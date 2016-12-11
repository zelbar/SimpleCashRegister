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
    public class DeleteReceiptCommand : ReceiptCommand, ICommand
    {
        public DeleteReceiptCommand(ArticleServices articleServices, ReceiptServices receiptServices) 
            : base(articleServices, receiptServices)
        {
        }

        public bool AdminOnly { get { return true; } }

        public string Description { get { return "Deletes an existing receipt by id."; } }

        public string Name { get { return "delete-receipt"; } }

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
            try
            {
                _receiptServices.DeleteReceipt(receiptId);
                Console.WriteLine("Receipt successfully deleted. Long live the tax evasion!");
            }
            catch(EntityNotFoundException)
            {
                Console.Error.WriteLine(">>> Receipt with specified id wasn't found.");
                return;
            }
        }
    }
}
