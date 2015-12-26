using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class ChangeDirectTransaction: ChangeMethodTransaction
    {
        private readonly string bank, account;
 

        public ChangeDirectTransaction(int id, string bank, string account) : base(id) 
        {
            this.bank = bank;
            this.account = account;
        }

        protected override PaymentMethod Method { get { return new DirectDepositMethod(bank, account); } }
    }
}
