using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class TimeCard
    {
        private readonly DateTime date;
        private readonly double hours;

        public TimeCard(DateTime date, double hours)
        {
            this.date = date;
            this.hours = hours;
        }
        public double Hours { get { return hours; } }
        public DateTime Date { get { return date; } }
    }
}
