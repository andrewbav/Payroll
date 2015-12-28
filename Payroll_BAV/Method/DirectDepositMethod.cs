using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class DirectDepositMethod: PaymentMethod
    {
        private string bank;
        private string account;

        public DirectDepositMethod(string bank, string account)
        {
            this.bank = bank;
            this.account = account;
        }
        public string Bank { get { return bank; } }
        public string Account { get { return account; } }
        public override string ToString() { return String.Format("Direct {0} {1}", bank, account); }
        public void Pay(Paycheck paycheck) { }
    }
}
