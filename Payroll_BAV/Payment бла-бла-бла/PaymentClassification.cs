using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public abstract class PaymentClassification
    {
        public abstract double CalculatePay(Paycheck paycheck);
    }
}
