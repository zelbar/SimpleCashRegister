using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Commands
{
    class HelpCommand : ICommand
    {
        public bool AdminOnly { get { return false; } }

        public string Name { get { return "help"; } }
        public string Description { get { return "Displays all the available commands and their parameters"; } }

        public void Execute(string[] args)
        {
            var registry = new CommandRegistry();

            if (args.Length == 1)
            {
                foreach (var command in registry.AllCommands)
                {
                    Console.WriteLine("{0}\n\t{1}", command.Name, command.Description);
                }
            }
            else
            {
                var command = registry.AllCommands.FirstOrDefault(x => x.Name == args[1]);
                if (command == null)
                    command = registry.AllCommands.FirstOrDefault(x => x.Name.Contains(args[1]));

                if (command == null)
                {
                    Console.WriteLine("No such command found.");
                }
                else
                {
                    Console.WriteLine("{0}: {1}", command.Name, command.Description);
                }
            }
        }
    }
}
