using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    class User : Entity<Guid>
    {
        public User(string username, string password) : base(new Guid())
        {
            Username = username;
            PasswordHash = password.GetHashCode();
            DateTimeCreated = DateTime.Now;
        }

        public string DisplayName { get; set; }
        public string Username { get; set; }
        public int PasswordHash { get; set; }
        public DateTime DateTimeCreated { get; }
    }
}
