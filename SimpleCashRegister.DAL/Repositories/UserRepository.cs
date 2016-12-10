using SimpleCashRegister.Model;
using System;
using System.Linq;
using SimpleCashRegister.DAL.Persisters;

namespace SimpleCashRegister.DAL.Repositories
{
    public class UserRepository : Repository<string, User>
    {
        public UserRepository(XmlPersister<User> persister) : base(persister)
        {
        }
    }
}
