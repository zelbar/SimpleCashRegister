using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Commands
{
    public class HelpCommand : ICommand
    {
        public HelpCommand(Dictionary<string, ICommand> commands)
        {
            _commands = commands;
        }

        private readonly Dictionary<string, ICommand> _commands;

        public bool AdminOnly { get { return false; } }

        public string Name { get { return "help"; } }
        public string Description { get { return "Displays all the available commands and their parameters"; } }

        public void Execute(string[] args)
        {
            if (args.Length <= 1)
            {
                foreach (var command in _commands)
                {
                    Console.WriteLine("{0}\n\t{1}", command.Key, command.Value.Description);
                }
            }
            else
            {
                ICommand cmd;
                if (_commands.TryGetValue(args[1], out cmd))
                {
                    Console.WriteLine("{0}\n\t{1}", cmd.Name, cmd.Description);
                }
            }
        }
    }
}
