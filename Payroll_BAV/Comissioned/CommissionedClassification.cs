using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class CommissionedClassification: PaymentClassification
    {
        private readonly double cRate, salary;

        public CommissionedClassification(double cRate, double salary) { this.cRate = cRate; this.salary = salary; }

        public double CRate { get { return cRate; } }
        public double Salary { get { return salary; } }

        public override string ToString() { return String.Format("${0} ${0}", cRate, salary); }
    }
}
