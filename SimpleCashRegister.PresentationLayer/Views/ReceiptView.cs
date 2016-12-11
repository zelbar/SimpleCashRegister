using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Model;

namespace SimpleCashRegister.PresentationLayer.Views
{
    public class ReceiptView : IView<Receipt>
    {
        private static readonly string CurrencyFormatSpecifier = "C";
        public string Display(Receipt receipt)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("ID: {0}\nIssued at {1}\n", receipt.Id, receipt.DateTimeIssued);
            
            foreach(var item in receipt.Items)
            {
                sb.AppendFormat("\t{0}; {1} x {2} = {3} (+{4}% VAT) = {5}\n",
                    item.Article.Name, item.GetUnitsString(), 
                    item.Article.NominalPrice.ToString(CurrencyFormatSpecifier),
                    item.GetCost().ToString(CurrencyFormatSpecifier),
                    100 * item.Article.VatRate, 
                    ((1 + item.Article.VatRate) * item.GetCost()).ToString(CurrencyFormatSpecifier));
            }

            sb.AppendFormat("Total: {0}; Total including VAT: {1}\n", 
                receipt.TotalCost.ToString(CurrencyFormatSpecifier), 
                receipt.TotalCostIncludingVat.ToString(CurrencyFormatSpecifier));

            var rv = sb.ToString();
            return rv;
        }
    }
}
