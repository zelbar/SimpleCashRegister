using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    class AdminUser : User
    {
        public AdminUser(string username, string password) : base(username, password)
        {
        }
    }
}
