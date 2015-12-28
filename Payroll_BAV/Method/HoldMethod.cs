using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class HoldMethod : PaymentMethod
    {
        public void Pay(Paycheck paycheck)
        {
            paycheck.Setfield("Disposition","Hold");
        }

        public override string ToString() { return "Hold"; }
    }
}
