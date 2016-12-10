using SimpleCashRegister.Model;

namespace SimpleCashRegister.DAL.Persisters
{
    public class UserPersister : XmlPersister<User>
    {
        public UserPersister(string filename) : base(filename)
        {
        }
    }
}
