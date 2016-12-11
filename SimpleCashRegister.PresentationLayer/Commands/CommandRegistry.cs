using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Commands
{
    class CommandRegistry
    {
        public List<ICommand> AllCommands = Assembly
            .GetExecutingAssembly().GetTypes()
            .Where(x => x.GetInterfaces().Contains(typeof(ICommand))
                        && x.GetConstructor(Type.EmptyTypes) != null)
            .Select(x => Activator.CreateInstance(x) as ICommand).ToList();
    }
}
