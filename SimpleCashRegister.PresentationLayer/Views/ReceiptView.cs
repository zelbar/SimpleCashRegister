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
                sb.AppendFormat("\t{0} x {1}; {2} (+{3}% VAT) = {4}\n",
                    item.GetUnitsString(), item.Article.Name, item.Article.Price.ToString(CurrencyFormatSpecifier), 
                    item.Article.VatRate * 100, item.Article.PriceIncludingVat.ToString(CurrencyFormatSpecifier));
            }

            sb.AppendFormat("Total: {0}; Total including VAT: {1}\n", 
                receipt.TotalCost.ToString(CurrencyFormatSpecifier), 
                receipt.TotalCostIncludingVat.ToString(CurrencyFormatSpecifier));

            var rv = sb.ToString();
            return rv;
        }
    }
}
