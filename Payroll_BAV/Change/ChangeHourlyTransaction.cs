using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class ChangeHourlyTransaction: ChangeClassificationTransaction
    {
        private readonly double hourlyRate;
        public ChangeHourlyTransaction(int id, double hourlyRate) : base(id) { this.hourlyRate = hourlyRate; }
        protected override PaymentClassification Classification { get { return new HourlyClassification(hourlyRate); } }
        protected override PaymentSchedule Schedule { get { return new HourlySchedule(); } }
    }
}
