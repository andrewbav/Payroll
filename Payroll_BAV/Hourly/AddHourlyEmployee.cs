using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class AddHourlyEmployee: AddEmployeeTransaction
    {
        private readonly double rate;

        public AddHourlyEmployee(int id, string name, string address, double rate)
            : base(id, name, address) { this.rate = rate; }

        protected override PaymentClassification MakeClassification() { return new HourlyClassification(rate); }

        protected override PaymentSchedule MakeSchedule() { return new HourlySchedule(); }
    }
}
