using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public class ChangeMailTransaction: ChangeMethodTransaction
    {
        private readonly string mailAddress;
        public ChangeMailTransaction(int id, string mailAddress) : base(id) { this.mailAddress = mailAddress; }
        protected override PaymentMethod Method { get { return new MailMethod(mailAddress); } }
    }
}
