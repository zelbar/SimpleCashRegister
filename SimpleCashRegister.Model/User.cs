using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleCashRegister.Model
{
    [Serializable]
    [XmlInclude(typeof(AdminUser))]
    [XmlInclude(typeof(CashierUser))]
    public class User : Entity<string>
    {
        private static readonly string UndefinedUserId = "new";
        public User() : base(UndefinedUserId) { }
        public User(string username, string password) : base(username)
        {
            PasswordHash = password.GetHashCode();
            DateTimeCreated = DateTime.Now;
        }

        public string DisplayName { get; set; }
        public int PasswordHash { get; set; }
        public DateTime DateTimeCreated { get; }
    }
}
