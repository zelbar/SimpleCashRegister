﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Exceptions
{
    public class SimpleCashRegisterException : ApplicationException { }
    public class UserException : SimpleCashRegisterException { }
}