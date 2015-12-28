using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    class NoAffilation : Affilation
    {
        public double CalculateDeductions(Paycheck paycheck){ return 0; }
    }
}
