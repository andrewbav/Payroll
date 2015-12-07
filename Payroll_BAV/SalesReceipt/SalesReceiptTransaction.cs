using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class SalesReceiptTransaction
    {
        private readonly DateTime date;
        private readonly double amount;
        private readonly int empId;

        public SalesReceiptTransaction(DateTime date, double amount, int empId)
        {
            this.date = date;
            this.amount = amount;
            this.empId = empId;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empId);
            if (e != null)
            {
                CommissionedClassification hc = e.Classification as CommissionedClassification;
                if (hc != null)
                    hc.AddTimeCard(new TimeCard(date, amount));
                else
                    throw new InvalidOperationException("попытка добавить карточку табельного учёта" +
                                                        "для работника не на комиссионной оплате");
            }
            else
                throw new InvalidOperationException("работник не найден");
        }
    }
}
