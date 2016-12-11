using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Commands
{
    public class HelpCommand : ICommand
    {
        public bool AdminOnly { get { return false; } }

        public string Name { get { return "help"; } }
        public string Description { get { return "Displays all the available commands and their parameters"; } }

        public void Execute()
        {
            var line = Console.ReadLine();
            var registry = new List<ICommand>();

            //if (args.Length == 1)
            //{
                foreach (var command in registry)
                {
                    Console.WriteLine("{0}\n\t{1}", command.Name, command.Description);
                }
            //}
            //else
            {
                var command = registry.FirstOrDefault(x => x.Name == line);
                if (command == null)
                    command = registry.FirstOrDefault(x => x.Name.Contains(line));

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
