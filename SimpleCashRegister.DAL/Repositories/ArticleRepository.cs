using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DAL.Persisters;
using SimpleCashRegister.Model;

namespace SimpleCashRegister.DAL.Repositories
{
    public class ArticleRepository : Repository<long, Article>
    {
        public ArticleRepository(XmlPersister<Article> persister) : base(persister)
        {
        }
    }
}
