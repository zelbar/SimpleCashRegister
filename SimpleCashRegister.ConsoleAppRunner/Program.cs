using System;
using System.Collections.Generic;
using SimpleCashRegister.Model;
using SimpleCashRegister.DataAccessLayer;
using SimpleCashRegister.DataAccessLayer.Persisters;
using SimpleCashRegister.DataAccessLayer.Repositories;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer;
using SimpleCashRegister.PresentationLayer.Commands;
using SimpleCashRegister.PresentationLayer.Commands.Account;
using SimpleCashRegister.PresentationLayer.Commands.Article;
using SimpleCashRegister.Exceptions;

namespace SimpleCashRegister.ConsoleAppRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var userPersister = new UserPersister("Users.xml");
            var articlePersister = new ArticlePersister("Articles.xml");
            var receiptPersister = new ReceiptPersister("Receipts.xml");

            var userRepository = new UserRepository(userPersister);
            var articleRepository = new ArticleRepository(articlePersister);
            var receiptRepository = new ReceiptRepository(receiptPersister);

            var accountServices = new AccountServices(userRepository);
            var articleServices = new ArticleServices(articleRepository, accountServices);
            var receiptServices = new ReceiptServices(articleRepository, receiptRepository);
            var reportServices = new ReportServices(articleRepository, receiptRepository);

            // Make sure to create the admin user if not present.
            User admin;
            try
            {
                admin = userRepository.GetById("admin");
            }
            catch (EntityNotFoundException)
            {
                accountServices.CreateUser("admin", "admin", true);
            }

            // Authenticate
            ICommand cmd = new LoginCommand(accountServices);
            cmd.Execute();
            
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
            cmd = new AddNewArticleCommand(articleServices);
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
