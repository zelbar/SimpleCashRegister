using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Model;
using SimpleCashRegister.Exceptions;

namespace SimpleCashRegister.PresentationLayer.Parsers
{
    class ArticleParser : IParser<Article>
    {
        public Article Parse(string line)
        {
            // id;type;name;price;vatrate
            var tokens = line.Split(';');

            int id;
            try
            {
                id = Convert.ToInt32(tokens[0]);
            }
            catch (FormatException)
            {
                throw new ParseException();
            }

            bool mass;
            if (tokens[1][0] == 'q')
                mass = false;
            else if (tokens[1][0] == 'm')
                mass = true;
            else
                throw new ParseException();

            string name = tokens[2];

            decimal price;
            try
            {
                price = Convert.ToDecimal(tokens[3]);
            }
            catch (FormatException)
            {
                throw new ParseException();
            }

            decimal vatRate;
            try
            {
                vatRate = Convert.ToDecimal(tokens[4]);
            }
            catch (FormatException)
            {
                throw new ParseException();
            }

            Article article;
            if (mass)
            {
                article = new ArticleSoldByMass(id)
                {
                    Name = name,
                    Price = price,
                    VatRate = vatRate
                };
            }
            else
            {
                article = new ArticleSoldByQuantity(id)
                {
                    Name = name,
                    Price = price,
                    VatRate = vatRate
                };
            }


            return article;
        }
    }
}
