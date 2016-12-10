using SimpleCashRegister.Model;

namespace SimpleCashRegister.DAL.Persisters
{
    public class ArticlePersister : XmlPersister<Article>
    {
        public ArticlePersister(string filename) : base(filename)
        {
        }
    }
}
