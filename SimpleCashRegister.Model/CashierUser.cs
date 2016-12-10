using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    public class CashierUser : User
    {
        public CashierUser() : base() { }
        public CashierUser(string username, string password) : base(username, password)
        {
        }
    }
}
