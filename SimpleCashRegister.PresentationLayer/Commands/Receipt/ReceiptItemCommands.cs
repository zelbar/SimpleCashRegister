using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;
using SimpleCashRegister.Model;
using SimpleCashRegister.Exceptions;
using SimpleCashRegister.PresentationLayer.Parsers;

namespace SimpleCashRegister.PresentationLayer.Commands.Receipt
{
    public class ReceiptItemCommands
    {
        public ReceiptItemCommands(ArticleServices articleServices, Model.Receipt receipt)
        {
            _articleServices = articleServices;
            _receipt = receipt;
        }

        private readonly ArticleServices _articleServices;
        private Model.Receipt _receipt;

        public void AddItem()
        {
            Console.WriteLine("Enter article id and quantity in number or kilograms (eg. 325 2): ");
            string line = Console.ReadLine();
            var articleIdText = line.Split(' ')[0];
            var quantityText = line.Split(' ')[1];

            long id = default(long);
            try
            {
                id = Convert.ToInt64(articleIdText);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Couldn't parse article id.");
                return;
            }


            var article = _articleServices.GetById(id);
            if (article != null)
            {
                Item item = default(Item);
                if (article is ArticleSoldByQuantity)
                {
                    var parser = new QuantityParser();
                    uint quantity = parser.Parse(quantityText);

                    item = new ItemSoldByQuantity()
                    {
                        Article = article,
                        Quantity = quantity
                    };

                }
                else if (article is ArticleSoldByMass)
                {
                    var parser = new MassParser();
                    decimal mass = parser.Parse(quantityText);

                    item = new ItemSoldByMass()
                    {
                        Article = article,
                        Mass = mass
                    };
                }
                else
                {
                    Console.Error.WriteLine("Unknown article type.");
                    return;
                }
                
                _receipt.Items.Add(item);
            }
        }

        public void DeleteItem()
        {
            Console.WriteLine("Enter article id to delete: ");
        }
    }
}
