using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Views
{
    public class ErrorView : IView<string>
    {
        public string Display(string message)
        {
            return "ERROR:\n" + message + "\n";
        }
    }
}
