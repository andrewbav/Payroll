using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class ChangeUnaffiliatedTransaction: ChangeAffiliationTransaction
    {
        public ChangeUnaffiliatedTransaction(int empid): base(empid) { }

        protected override Affilation Affilation{ get { return new NoAffilation(); } }

        protected override void RecordMembership(Employee e)
        {
            Affilation affilation = e.Affilation;
            if (affilation is UnionAffilation)
            {
                UnionAffilation unionAffilation = affilation as UnionAffilation;
                int memberId = unionAffilation.MemberId;
                PayrollDatabase.DeleteUnionMember(memberId);
            }
        }
    }
}
