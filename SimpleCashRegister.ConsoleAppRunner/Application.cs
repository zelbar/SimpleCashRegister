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
using System.Threading.Tasks;

namespace SimpleCashRegister.ConsoleAppRunner
{
    class Application
    {
        static Task Run()
        {
            var userPersister = new UserPersister("Users.xml");
            var articlePersister = new ArticlePersister("Articles.xml");
            var receiptPersister = new ReceiptPersister("Receipts.xml");

            var userRepository = new UserRepository(userPersister);
            var articleRepository = new ArticleRepository(articlePersister);
            var receiptRepository = new ReceiptRepository(receiptPersister);

            var accountServices = new AccountServices(userRepository);
            var articleServices = new ArticleServices(articleRepository);
            var receiptServices = new ReceiptServices(articleRepository, receiptRepository);
            var reportServices = new ReportServices(articleRepository, receiptRepository);

            IEnumerable<ICommand> commandRepository = new List<ICommand>()
            {

            };

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
            ICommand cmd = new LoginAccountCommand(accountServices);
            cmd.Execute();
            
            // Articles from CLI to add!
            cmd = new AddNewArticleCommand(articleServices);
            cmd.Execute();

            cmd = new EditArticleCommand(articleServices);
            cmd.Execute();


            // THIS SHOULD GO TO THE RECEIPT COMMAND!
            var receiptView = new PresentationLayer.Views.ReceiptView();
            foreach (var receipt in receiptRepository.GetAll())
            {
                Console.WriteLine(receiptView.Display(receipt));
            }

            return Task.CompletedTask;
        }
    }
}
