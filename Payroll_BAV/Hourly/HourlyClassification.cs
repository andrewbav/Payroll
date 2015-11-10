using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class HourlyClassification: PaymentClassification
    {
        protected readonly double rate;

        public HourlyClassification(double rate) { this.rate = rate; }

        public double Rate { get { return rate; } }

        public override string ToString() { return String.Format("${0}", rate); }
    }
}
