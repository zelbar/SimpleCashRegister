using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleCashRegister.Model
{
    [Serializable]
    public class ArticleSoldByQuantity : Article
    {
        public ArticleSoldByQuantity() : base(UndefinedArticleId) { }
        public ArticleSoldByQuantity(int id) : base(id)
        {
        }
    }
}
