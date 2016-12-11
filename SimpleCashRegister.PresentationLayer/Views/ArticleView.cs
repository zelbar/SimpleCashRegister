using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Model;

namespace SimpleCashRegister.PresentationLayer.Views
{
    public class ArticleView : IView<Article>
    {
        private static readonly string CurrencyFormatSpecifier = "C";
        public string Display(Article article)
        {
            //{id}: {Name}; {Price} + ({VatRate}% VAT) = {PriceIncludingVat}
            
            var rv = string.Format("{0}: {1}; {2} (+{3}% VAT) = {4}",
                    article.Id, article.Name, article.NominalPrice.ToString(CurrencyFormatSpecifier), 
                    article.VatRate * 100, article.PriceIncludingVat.ToString(CurrencyFormatSpecifier));
            
            return rv;
        }
    }
}
