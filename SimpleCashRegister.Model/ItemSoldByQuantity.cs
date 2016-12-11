using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    public class ItemSoldByQuantity : Item
    {
        public uint Quantity { get; set; } = 1;

        public override decimal GetCost()
        {
            return Article.NominalPrice * Quantity;
        }

        public override decimal GetUnits()
        {
            return Quantity;
        }

        public override string GetUnitsString()
        {
            return Convert.ToString((decimal)GetUnits());
        }
    }
}
