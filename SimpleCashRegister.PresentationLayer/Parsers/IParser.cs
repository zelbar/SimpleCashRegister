using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Parsers
{
    interface IParser<T>
    {
        T Parse(string line);
    }
}
