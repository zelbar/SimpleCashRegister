﻿using SimpleCashRegister.PresentationLayer.Parsers;
using SimpleCashRegister.Exceptions;
using SimpleCashRegister.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.PresentationLayer.Commands.Report
{
    class DailyReportCommand : ReportCommand, ICommand
    {
        public DailyReportCommand(ReportServices reportServices) : base(reportServices)
        {
        }

        public bool AdminOnly { get { return false; } }

        public string Description { get { return "Shows report of sold articles for specified day"; } }

        public string Name { get { return "daily-report"; } }

        public void Execute()
        {
            Console.WriteLine("DAILY REPORT");
            var line = Console.ReadLine();
            var parser = new DateParser();

            DateTime dt = default(DateTime);
            try
            {
                dt = parser.Parse(line);
            }
            catch(ParseException)
            {
                Console.Error.WriteLine("Invalid date input.");
            }

            var dailyReport = _reportServices.DailyReport(dt);
        }
    }
}