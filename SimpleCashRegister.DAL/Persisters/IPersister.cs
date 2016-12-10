using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.DAL.Persisters
{
    interface IPersister<T>
    {
        void Load();
        void Save();
    }
}
