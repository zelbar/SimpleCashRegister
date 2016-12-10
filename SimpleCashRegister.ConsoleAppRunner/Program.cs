using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DAL;
using SimpleCashRegister.Model;

namespace SimpleCashRegister.ConsoleAppRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var usersPersister = new DAL.Persisters.UserPersister("Users.xml");
            var usersRepo = new DAL.Repositories.UserRepository(usersPersister);

            var articlesPersister = new DAL.Persisters.ArticlePersister("Articles.xml");
            var articlesRepo = new DAL.Repositories.ArticleRepository(articlesPersister);
            
            var receiptsPersister = new DAL.Persisters.ReceiptPersister("Receipts.xml");
            var receiptsRepo = new DAL.Repositories.ReceiptRepository(receiptsPersister);

            // Adding users
            User admin;
            try
            {
                admin = usersRepo.GetById("admin");
            }
            catch(EntityNotFoundException e)
            {
                Console.WriteLine(e.Message);
                var userToAdd = new AdminUser("admin", "admin")
                {
                    DisplayName = "Zvonimir Vanjak"
                };

                usersRepo.Add(userToAdd);
                Console.WriteLine("User " + userToAdd.DisplayName + " added");
            }

            // Adding articles
            var articlesToAdd = new List<Article>
            {
                new ArticleSoldByQuantity(10)
                {
                    Name = "Programming in C#",
                    Price = (decimal)23.44,
                    VatRate = (decimal)0.15
                },
                new ArticleSoldByMass(10)
                {
                    Name = "Almonds",
                    Price = (decimal)15.21,
                    VatRate = (decimal)0.20
                }
            };
                    

            try
            {
                foreach (var article in articlesToAdd)
                    articlesRepo.Add(article);
            }
            catch (EntityAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var article in articlesRepo.GetAll())
            {
                Console.WriteLine("{0}: {1}; {2} (+{3}% VAT) = {4}", 
                    article.Id, article.Name, article.Price, article.VatRate * 100, article.PriceIncludingVat);
            }

            var receiptFacotry = new Model.Factories.ReceiptFactory();
            //var rnd = new Random();
            var items = new List<Item>()
            {
                new ItemSoldByQuantity()
                {
                    Article = articlesToAdd[0]
                },
                new ItemSoldByMass()
                {
                    Article = articlesToAdd[1]
                }
            };
            var receiptToAdd = receiptFacotry.CreateReceipt(items);

            receiptsRepo.Add(receiptToAdd);

            foreach (var receipt in receiptsRepo.GetAll())
            {
                Console.WriteLine(receipt.Id + ": " + receipt.DateTimeIssued);
                foreach (var item in receipt.Items)
                {
                    Console.WriteLine("\t{0} x {1}; {2} (+{3}% VAT) = {4}",
                    item.GetUnitsString(), item.Article.Name, item.Article.Price, item.Article.VatRate * 100, item.Article.PriceIncludingVat);
                }
            }

            Console.ReadKey();
        }
    }
}
