using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class CommissionedClassification: PaymentClassification
    {
        private readonly double cRate, salary;
        private Hashtable timeCards = new Hashtable();

        public TimeCard GetTimeCard(DateTime date) { return timeCards[date] as TimeCard; }
        public void AddTimeCard(TimeCard card) { timeCards[card.Date] = card; }
        public CommissionedClassification(double cRate, double salary) { this.cRate = cRate; this.salary = salary; }
        public double CRate { get { return cRate; } }
        public double Salary { get { return salary; } }
        public override string ToString() { return String.Format("${0} ${1}", cRate, salary); }
        public override double CalculatePay(Paycheck paycheck) { return 0; }
    }
}
