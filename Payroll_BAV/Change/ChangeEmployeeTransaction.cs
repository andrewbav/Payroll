using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public abstract class ChangeEmployeeTransaction: Transaction
    {
        private readonly int empId;

        public ChangeEmployeeTransaction(int empId) { this.empId = empId; }
        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empId);
            if (e != null)
                Change(e);
            else
                throw new InvalidOperationException("работник не найден");
        }
        protected abstract void Change(Employee e);
    }
}
