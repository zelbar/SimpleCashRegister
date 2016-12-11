using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Parsers
{
    public class ReceiptIdParser : IParser<Guid>
    {
        public Guid Parse(string line)
        {
            Guid guid;
            if (Guid.TryParse(line, out guid))
            {
                return guid;
            }
            else
            {
                Console.Error.WriteLine("Couldn't parse receipt id.");
            }
            return guid;
        }
    }
}
