using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class ChangeCommissionedTransaction: ChangeClassificationTransaction
    {
        private readonly double salary, cRate;

        public ChangeCommissionedTransaction(int id, double salary, double cRate) : base(id) 
        { 
            this.salary = salary;
            this.cRate = cRate;
        }
        protected override PaymentClassification Classification { get { return new CommissionedClassification(salary, cRate); } }
        protected override PaymentSchedule Schedule { get { return new BiweeklySchedule(); } }
    }
}
