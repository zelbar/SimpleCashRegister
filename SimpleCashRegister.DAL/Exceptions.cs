using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.DataAccessLayer
{
    public class SimpleCashRegisterException : ApplicationException { }
    public class EntityAlreadyExistsException : SimpleCashRegisterException { }
    public class EntityNotFoundException : SimpleCashRegisterException { }
}
