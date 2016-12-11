using System;

namespace SimpleCashRegister.Exceptions
{
    public class SimpleCashRegisterException : ApplicationException { }
    public class EntityAlreadyExistsException : SimpleCashRegisterException { }
    public class EntityNotFoundException : SimpleCashRegisterException { }
}
