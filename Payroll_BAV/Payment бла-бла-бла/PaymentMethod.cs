﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public interface PaymentMethod
    {
         void Pay(Paycheck paycheck);
    }
}
