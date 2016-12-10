using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleCashRegister.Model
{
    [Serializable]
    public class ArticleSoldByMass : Article
    {
        public ArticleSoldByMass() : base(UndefinedArticleId) { }
        public ArticleSoldByMass(int id) : base(id)
        {
        }
    }
}
