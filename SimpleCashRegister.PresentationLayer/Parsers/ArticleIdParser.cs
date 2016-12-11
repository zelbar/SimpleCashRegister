using SimpleCashRegister.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Parsers
{
    public class ArticleIdParser : IParser<long>
    {
        public long Parse(string line)
        {
            long id = 0;

            try
            {
                id = Convert.ToInt64(line);
            }
            catch (FormatException)
            {
                throw new ParseException();
            }

            return id;
        }
    }
}
