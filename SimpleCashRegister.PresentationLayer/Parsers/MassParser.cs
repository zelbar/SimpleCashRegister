using SimpleCashRegister.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Parsers
{
    class MassParser : IParser<decimal>
    {
        public decimal Parse(string line)
        {
            decimal mass = 0;

            try
            {
                mass = Convert.ToDecimal(line);
            }
            catch (FormatException)
            {
                throw new ParseException();
            }

            return mass;
        }
    }
}
