using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class ChangeHoldTransaction: ChangeMethodTransaction
    {
        public ChangeHoldTransaction(int id) : base(id) { }
        protected override PaymentMethod Method { get { return new HoldMethod(); } }
    }
}
