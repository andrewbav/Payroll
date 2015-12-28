using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class HourlySchedule: PaymentSchedule
    {
        //public bool IsPayDate(DateTime date) { return true; } //исправить 
        public bool IsPayDate(DateTime date){return date.DayOfWeek == DayOfWeek.Friday; }
        public DateTime GetPayPeriodStartDate(DateTime date){ return date.AddDays(-6); }

        public override string ToString() { return "Hourly"; }
    }
}
