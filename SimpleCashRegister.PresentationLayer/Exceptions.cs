using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer
{
    public class SimpleCashRegistryException : ApplicationException { }
    public class ParseException : SimpleCashRegistryException { }
}
