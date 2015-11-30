using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class HourlyClassification: PaymentClassification
    {
        protected readonly double rate;
        private Hashtable timeCards = new Hashtable();
    
        public TimeCard GetTimeCard(DateTime date) { return timeCards[date] as TimeCard; }
        public void AddTimeCard(TimeCard card) { timeCards[card.Date] = card; }
        public HourlyClassification(double rate) { this.rate = rate; }
        public double Rate { get { return rate; } }
        public override string ToString() { return String.Format("${0}", rate); }
    }
}
