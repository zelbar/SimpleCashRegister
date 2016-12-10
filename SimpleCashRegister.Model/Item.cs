using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    public abstract class Item
    {
        public Article Article;

        public abstract decimal GetCost();
        public abstract decimal GetUnits();
        public abstract string GetUnitsString();
    }
}
