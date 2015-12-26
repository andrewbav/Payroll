using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class ChangeMemberTransaction: ChangeAffiliationTransaction
    {

        private readonly int memberId;
        private readonly double charge;

        public ChangeMemberTransaction(int empid, int memberId, double charge): base(empid)
        {
            this.memberId = memberId;
            this.charge = charge;
        }

        protected override Affilation Affilation { get { return new UnionAffilation(memberId, charge); }}

        protected override void RecordMembership(Employee e){ PayrollDatabase.AddUnionMember(memberId, e); }
    }
}
