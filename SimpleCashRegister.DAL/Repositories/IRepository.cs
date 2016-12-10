using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.DAL.Repositories
{
    interface IRepository<TId, TItem>
    {
        TId Add(TItem item);

        void Edit(TItem item);

        TItem GetById(TId id);

        List<TItem> GetAll();

        void Delete(TId id);
    }
}
