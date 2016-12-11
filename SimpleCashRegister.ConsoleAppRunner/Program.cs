using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Model;
using SimpleCashRegister.DAL;
using SimpleCashRegister.PresentationLayer;
using SimpleCashRegister.PresentationLayer.Commands;

namespace SimpleCashRegister.ConsoleAppRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var usersPersister = new DAL.Persisters.UserPersister("Users.xml");
            var usersRepo = new DAL.Repositories.UserRepository(usersPersister);
            var accountsController = new Controllers.AccountsController(usersRepo);

            var articlesPersister = new DAL.Persisters.ArticlePersister("Articles.xml");
            var articlesRepo = new DAL.Repositories.ArticleRepository(articlesPersister);
            var articlesController = new Controllers.ArticlesController(articlesRepo, accountsController);
            
            var receiptsPersister = new DAL.Persisters.ReceiptPersister("Receipts.xml");
            var receiptsRepo = new DAL.Repositories.ReceiptRepository(receiptsPersister);
            var receiptsController = new Controllers.ReceiptsController(receiptsRepo);

            // Make sure to create the admin user if not present
            User admin;
            try
            {
                admin = usersRepo.GetById("admin");
            }
            catch (EntityNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                var userToAdd = new AdminUser("admin", "admin")
                {
                    DisplayName = "Zvonimir Vanjak"
                };

                usersRepo.Add(userToAdd);
                Console.WriteLine("User " + userToAdd.DisplayName + " with username \"admin\" added.");
            }

            // Authenticate
            Console.WriteLine("Please provide login details: username password");
            var accountController = new Controllers.AccountsController(usersRepo);
            bool success = false;
            do
            {
                string username = "", password = "";
                {
                    var line = Console.ReadLine();
                    try
                    {
                        username = line.Split(' ')[0];
                        password = line.Split(' ')[1];
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid format!");
                        continue;
                    }
                }
                success = accountController.Login(username, password);
            } while (!success);
            
            // Adding articles
            var articlesToAdd = new List<Article>
            {
                new ArticleSoldByQuantity(10)
                {
                    Name = "Programming in C#",
                    Price = (decimal)23.44,
                    VatRate = (decimal)0.15
                },
                new ArticleSoldByMass(15)
                {
                    Name = "Almonds",
                    Price = (decimal)15.21,
                    VatRate = (decimal)0.20
                }
            };

            // Articles from CLI to add!
            ICommand cmd = new AddNewArticleCommand(articlesController);
            cmd.Execute();
            
            foreach (var article in articlesToAdd)
            {
                articlesController.AddNewArticle(article);
            }

            cmd = new EditArticleCommand(articlesController);
            cmd.Execute();

            // Printing articles
            var articleView = new PresentationLayer.Views.ArticleView();
            foreach (var article in articlesController.GetAllArticles())
            {
                Console.WriteLine(articleView.Display(article));
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


            // THIS SHOULD GO TO THE RECEIPT COMMAND!
            var receiptView = new PresentationLayer.Views.ReceiptView();
            foreach (var receipt in receiptsRepo.GetAll())
            {
                Console.WriteLine(receiptView.Display(receipt));
            }

            Console.ReadKey();
        }
    }
}
