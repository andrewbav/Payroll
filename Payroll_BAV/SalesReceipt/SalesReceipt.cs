using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class SalesReceipt
    {
        private readonly DateTime date;
        private readonly double amount;

        public SalesReceipt(DateTime date, double hours)
        {
            this.date = date;
            this.amount = hours;
        }
        public double Hours { get { return amount; } }
        public DateTime Date { get { return date; } }
    }
}
