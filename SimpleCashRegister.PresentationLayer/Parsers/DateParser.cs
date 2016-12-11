using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Parsers
{
    class DateParser : IParser<DateTime>
    {
        public DateTime Parse(string line)
        {
            DateTime dt;
            if (DateTime.TryParse(line, out dt))
            {
                return dt;
            }
            else
            {
                throw new ParseException();
            }
        }
    }
}
