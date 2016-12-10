using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleCashRegister.Model
{
    [Serializable]
    [XmlInclude(typeof(ItemSoldByMass))]
    [XmlInclude(typeof(ItemSoldByQuantity))]
    [XmlInclude(typeof(ArticleSoldByMass))]
    [XmlInclude(typeof(ArticleSoldByQuantity))]
    public class Receipt : Entity<Guid>
    {
        public Receipt() : base(Guid.NewGuid())
        {
            DateTimeIssued = DateTime.Now;
        }

        public List<Item> Items { get; set; }
        public DateTime DateTimeIssued { get; set; }
        public decimal TotalCost
        {
            get
            {
                return Items.Sum(x => x.Article.Price);
            }
        }
        public decimal TotalCostIncludingVat
        {
            get
            {
                return Items.Sum(x => x.Article.PriceIncludingVat);
            }
        }
        public decimal TotalVat
        {
            get
            {
                return TotalCostIncludingVat - TotalCost;
            }
        }
    }
}
