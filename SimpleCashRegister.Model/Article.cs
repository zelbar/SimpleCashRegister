using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleCashRegister.Model
{
    [XmlInclude(typeof(ArticleSoldByMass))]
    [XmlInclude(typeof(ArticleSoldByQuantity))]
    public abstract class Article : Entity<long>
    {
        protected static readonly int UndefinedArticleId = -1;

        public Article() : base(UndefinedArticleId)
        {

        }
        public Article(int id) : base(id)
        {

        }
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal VatRate { get; set; }

        public decimal PriceIncludingVat
        {
            get
            {
                return Price * 100 * VatRate;
            }
        }
    }
}
