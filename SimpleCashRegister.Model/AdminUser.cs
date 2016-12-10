using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    public class AdminUser : User
    {
        public AdminUser() : base() { }
        public AdminUser(string username, string password) : base(username, password)
        {
        }
    }
}
