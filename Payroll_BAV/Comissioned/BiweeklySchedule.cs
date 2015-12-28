using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class BiweeklySchedule: PaymentSchedule
    {
        public bool IsPayDate(DateTime date) { return date.DayOfWeek == DayOfWeek.Friday; }
        public override string ToString() { return "BiWeekly"; }
    }
}
