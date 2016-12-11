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
                Console.Error.WriteLine("Couldn't parse quantity.");
            }

            return quantity;
        }
    }
}
