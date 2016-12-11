using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.Services;

namespace SimpleCashRegister.PresentationLayer.Commands.Report
{
    public class ReportCommand
    {
        public ReportCommand(ReportServices reportServices)
        {
            _reportServices = reportServices;
        }

        protected readonly ReportServices _reportServices;
    }
}
