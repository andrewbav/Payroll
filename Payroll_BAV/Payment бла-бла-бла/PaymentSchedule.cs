﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll_BAV
{
    public interface PaymentSchedule
    {
        bool IsPayDate(DateTime date);
    }
}
