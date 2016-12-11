using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DataAccessLayer.Persisters;
using SimpleCashRegister.Model;

namespace SimpleCashRegister.DataAccessLayer.Repositories
{
    public class ReceiptRepository : Repository<Guid, Receipt>
    {
        public ReceiptRepository(XmlPersister<Receipt> persister) : base(persister)
        {
        }
    }
}
