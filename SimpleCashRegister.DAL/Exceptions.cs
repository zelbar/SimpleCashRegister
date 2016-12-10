using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.DAL
{
    public class SimpleCashRegisterException : Exception { }
    public class EntityAlreadyExistsException : SimpleCashRegisterException { }
    public class EntityNotFoundException : SimpleCashRegisterException { }
}
