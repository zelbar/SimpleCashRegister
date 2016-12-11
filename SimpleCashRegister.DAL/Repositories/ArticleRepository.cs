using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DataAccessLayer.Persisters;
using SimpleCashRegister.Model;

namespace SimpleCashRegister.DataAccessLayer.Repositories
{
    public class ArticleRepository : Repository<long, Article>
    {
        public ArticleRepository(XmlPersister<Article> persister) : base(persister)
        {
        }
    }
}
