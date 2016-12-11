using SimpleCashRegister.Model;

namespace SimpleCashRegister.DataAccessLayer.Persisters
{
    public class ArticlePersister : XmlPersister<Article>
    {
        public ArticlePersister(string filename) : base(filename)
        {
        }
    }
}
