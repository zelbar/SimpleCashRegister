using System;
using System.Collections.Generic;
using SimpleCashRegister.Model;
using SimpleCashRegister.DAL;
using SimpleCashRegister.DAL.Persisters;
using SimpleCashRegister.DAL.Repositories;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer;
using SimpleCashRegister.PresentationLayer.Commands;

namespace SimpleCashRegister.ConsoleAppRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var userPersister = new UserPersister("Users.xml");
            var userRepository = new UserRepository(userPersister);
            var accountServices = new AccountServices(userRepository);

            var articlePersister = new ArticlePersister("Articles.xml");
            var articleRepository = new ArticleRepository(articlePersister);
            var articleServices = new ArticleServices(articleRepository, accountServices);
            
            var receiptPersister = new ReceiptPersister("Receipts.xml");
            var receiptRepository = new ReceiptRepository(receiptPersister);
            var receiptServices = new ReceiptServices(receiptRepository);

            // Make sure to create the admin user if not present
            User admin;
            try
            {
                admin = userRepository.GetById("admin");
            }
            catch (EntityNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                var userToAdd = new AdminUser("admin", "admin")
                {
                    DisplayName = "Zvonimir Vanjak"
                };

                userRepository.Add(userToAdd);
                Console.WriteLine("User " + userToAdd.DisplayName + " with username \"admin\" added.");
            }

            // Authenticate
            Console.WriteLine("Please provide login details: username password");
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
                success = accountServices.Login(username, password);
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
            ICommand cmd = new AddNewArticleCommand(articleServices);
            cmd.Execute();
            
            foreach (var article in articlesToAdd)
            {
                articleServices.AddNewArticle(article);
            }

            cmd = new EditArticleCommand(articleServices);
            cmd.Execute();

            // Printing articles
            var articleView = new PresentationLayer.Views.ArticleView();
            foreach (var article in articleServices.GetAllArticles())
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

            receiptRepository.Add(receiptToAdd);


            // THIS SHOULD GO TO THE RECEIPT COMMAND!
            var receiptView = new PresentationLayer.Views.ReceiptView();
            foreach (var receipt in receiptRepository.GetAll())
            {
                Console.WriteLine(receiptView.Display(receipt));
            }

            Console.ReadKey();
        }
    }
}
