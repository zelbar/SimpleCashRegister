using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Commands
{
    interface ICommand
    {
        string Name { get; }
        string Description { get; }
        bool AdminOnly { get; }
        void Execute(string[] args);
    }
}
