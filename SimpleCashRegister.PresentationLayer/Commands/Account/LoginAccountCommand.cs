using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;

namespace SimpleCashRegister.PresentationLayer.Commands.Account
{
    public class LoginAccountCommand : AccountCommand, ICommand
    {
        public LoginAccountCommand(AccountServices accountServices) : base(accountServices)
        {
        }

        public bool AdminOnly { get { return false; } }

        public string Description { get { return "Used to authenticate a user (cashier or administrator)."; } }

        public string Name { get { return "login"; } }

        public void Execute(string[] args)
        {
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
                success = _accountServices.Login(username, password);
            } while (!success);
        }
    }
}
