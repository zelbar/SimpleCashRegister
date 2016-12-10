using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model.Factories
{
    public class ReceiptFactory
    {
        public Receipt CreateReceipt(List <Item> items)
        {
            var receipt = new Receipt();
            receipt.Items = items;
            return receipt;
        }
    }
}
