using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class AddComissionedEmployee: AddEmployeeTransaction
    {
        private readonly double cRate, salary;

        public AddComissionedEmployee(int id, string name, string address, double cRate, double salary)
            : base(id, name, address) { this.cRate = cRate; this.salary = salary; }

        protected override PaymentClassification MakeClassification() { return new CommissionedClassification(cRate,salary); }

        protected override PaymentSchedule MakeSchedule() { return new BiweeklySchedule(); }
    }
}
