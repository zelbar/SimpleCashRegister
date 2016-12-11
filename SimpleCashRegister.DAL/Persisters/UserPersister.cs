using SimpleCashRegister.Model;

namespace SimpleCashRegister.DataAccessLayer.Persisters
{
    public class UserPersister : XmlPersister<User>
    {
        public UserPersister(string filename) : base(filename)
        {
        }
    }
}
