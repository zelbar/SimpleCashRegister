using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    public class ItemSoldByMass : Item
    {
        public decimal Mass { get; set; } = 1;

        public override decimal GetCost()
        {
            return Article.NominalPrice * Mass;
        }

        public override decimal GetUnits()
        {
            Debug.Assert(Mass != default(decimal));
            return Mass;
        }

        public override string GetUnitsString()
        {
            return Mass + " kg";
        }
    }
}
