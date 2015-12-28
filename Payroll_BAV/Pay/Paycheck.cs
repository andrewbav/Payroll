using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class Paycheck
    {
        private DateTime payDate;
        private double grossPay, deductions, netPay;
        private readonly DateTime payPeriodStartDate;
        public void Setfield(string fieldName, string value) { fields[fieldName] = value; }

    private Hashtable fields = new Hashtable();

        public Paycheck( DateTime payDate){ this.payDate = payDate; }
        //public Paycheck(DateTime payPeriodStartDate, DateTime payDate)
        //{
        //    this.payDate = payDate;
        //    this.payPeriodStartDate = payPeriodStartDate;
        //}
        //public DateTime PayPeriodStartDate {get { return payPeriodStartDate; } } ///
        public DateTime PayDate { get { return payDate; } }
        public string GetField(string fieldName){ return fields[fieldName] as string; }
        public double GrossPay
        {
            get { return grossPay; }
            set { grossPay = value; }
        }
        public double Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }
        public double NetPay
        {
            get { return netPay; }
            set { netPay = value; }
        }

    }
}
