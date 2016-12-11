using SimpleCashRegister.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Parsers
{
    class QuantityParser : IParser<uint>
    {
        public uint Parse(string line)
        {
            uint quantity = 1;

            try
            {
                quantity = Convert.ToUInt32(line);
            }
            catch (FormatException)
            {
                throw new ParseException();
            }

            return quantity;
        }
    }
}
