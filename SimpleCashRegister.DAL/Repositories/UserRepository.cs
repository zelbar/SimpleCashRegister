using SimpleCashRegister.Model;
using System;
using System.Linq;
using SimpleCashRegister.DataAccessLayer.Persisters;

namespace SimpleCashRegister.DataAccessLayer.Repositories
{
    public class UserRepository : Repository<string, User>
    {
        public UserRepository(XmlPersister<User> persister) : base(persister)
        {
        }
    }
}
