using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    class ServiceChargeTransaction : Transaction
    {
        private readonly DateTime time;
        private readonly double charge;
        private readonly int memberId;

        public ServiceChargeTransaction(int id, DateTime time, double charge)
        {
            this.memberId = id;
            this.time = time;
            this.charge = charge;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetUnionMember(memberId);
            if (e != null)
            {
                UnionAffilation ua = null;
                if (e.Affilation is UnionAffilation)
                    ua = e.Affilation as UnionAffilation;
                if (ua != null)
                    ua.AddServiceCharge(new ServiceCharge(time, charge));
                else
                    throw new InvalidOperationException("попытка добавить плату за услуги для члена профсоюза " +
                                                        "с незарегестрированным членством");
            }
            else
                throw new InvalidOperationException("член профсоюза не найден");
        }

    }
}
