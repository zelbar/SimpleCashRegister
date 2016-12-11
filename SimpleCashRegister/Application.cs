using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SimpleCashRegister.Model;
using SimpleCashRegister.DataAccessLayer.Persisters;
using SimpleCashRegister.DataAccessLayer.Repositories;
using SimpleCashRegister.Services;
using SimpleCashRegister.PresentationLayer.Commands;
using SimpleCashRegister.PresentationLayer.Commands.Account;
using SimpleCashRegister.PresentationLayer.Commands.Article;
using SimpleCashRegister.PresentationLayer.Commands.Receipt;
using SimpleCashRegister.PresentationLayer.Commands.Report;
using SimpleCashRegister.Exceptions;

namespace SimpleCashRegister
{
    public class Application
    {
        private void AssignCommands(out Dictionary<string, ICommand> commandsDictionary,
            AccountServices accountServices, ArticleServices articleServices, 
            ReceiptServices receiptServices, ReportServices reportServices)
        {
            var allCommands = new List<ICommand>()
            {
                new LoginAccountCommand(accountServices),
                new AddNewArticleCommand(articleServices),
                new EditArticleCommand(articleServices),
                new DeleteArticleCommand(articleServices),
                new CreateNewReceiptCommand(articleServices, receiptServices),
                //new EditReceiptCommand
                new DeleteReceiptCommand(articleServices, receiptServices),
                new DailyReportCommand(reportServices),
                new BestSellingArticlesReportCommand(reportServices),
            };

            commandsDictionary = new Dictionary<string, ICommand>();
            foreach (var cmd in allCommands)
            {
                if (cmd.AdminOnly && accountServices.AsAdmin || !cmd.AdminOnly)
                    commandsDictionary.Add(cmd.Name, cmd);
            }

            commandsDictionary.Add("help", new HelpCommand(commandsDictionary));
        }
        public Task Run()
        {
            // Create XML file persistors.
            var userPersister = new UserPersister("Users.xml");
            var articlePersister = new ArticlePersister("Articles.xml");
            var receiptPersister = new ReceiptPersister("Receipts.xml");

            // Create repositories.
            var userRepository = new UserRepository(userPersister);
            var articleRepository = new ArticleRepository(articlePersister);
            var receiptRepository = new ReceiptRepository(receiptPersister);

            // Create services.
            var accountServices = new AccountServices(userRepository);
            var articleServices = new ArticleServices(articleRepository);
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

            // Authenticate.
            ICommand cmd = new LoginAccountCommand(accountServices);
            cmd.Execute(null);


            // Assign authorized commands.
            Dictionary<string, ICommand> commands;
            AssignCommands(out commands, accountServices, articleServices, receiptServices, reportServices);

            // Read commands.
            string line = "help";
            do
            {
                try
                {
                    var commandName = line.Split(' ')[0];
                    cmd = commands[commandName];
                    cmd.Execute(line.Split(' '));
                }
                catch (KeyNotFoundException)
                {
                    Console.Error.WriteLine("Command not found.");
                }

                line = Console.ReadLine();
            } while (line != "exit");

            return Task.CompletedTask;
        }
    }
}
