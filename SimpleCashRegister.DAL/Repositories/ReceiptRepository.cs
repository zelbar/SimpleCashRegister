using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DAL.Persisters;
using SimpleCashRegister.Model;

namespace SimpleCashRegister.DAL.Repositories
{
    public class ReceiptRepository : Repository<Guid, Receipt>
    {
        public ReceiptRepository(XmlPersister<Receipt> persister) : base(persister)
        {
        }
    }
}
