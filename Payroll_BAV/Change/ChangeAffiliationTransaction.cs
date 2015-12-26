using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public abstract class ChangeAffiliationTransaction: ChangeEmployeeTransaction
    {
        public ChangeAffiliationTransaction(int empid): base(empid) { }

        protected override void Change(Employee e)
        {
            RecordMembership(e);
            Affilation affilation = Affilation;
            e.Affilation = affilation;
        }

        protected abstract Affilation Affilation { get; }
        protected abstract void RecordMembership(Employee e);
    }
}
