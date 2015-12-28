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

        public override double CalculatePay(Paycheck paycheck)
        {
            double totalPay = 0.0;
            foreach (TimeCard timeCard in timeCards.Values)
                if (timeCard.Date == paycheck.PayDate)
                    totalPay += CalculatePayForTimeCard(timeCard);
            return totalPay;
        }

        private double CalculatePayForTimeCard(TimeCard card)
        {
            double overtimeHours = Math.Max(0.0, card.Hours - 8);
            double normalHours = card.Hours - overtimeHours;
            return rate * normalHours + rate * 1.5 * overtimeHours;
        }

        private bool IsInPayPeriod(DateTime card, DateTime payPeriod)
        {
            DateTime payPeriodEndDate = payPeriod;
            DateTime payPeriodStartDate = payPeriod.AddDays(-7);
            return card.Date <= payPeriodEndDate && card.Date >= payPeriodStartDate;
        }

        //public override double CalculatePay(Paycheck paycheck)
        //{
        //    double totalPay = 0;
        //    foreach (TimeCard timeCard in timeCards.Values)
        //        if (timeCard.Date == paycheck.PayDate)
        //            totalPay += timeCard.Hours * rate;
        //    return totalPay;
        //}
    }
}
