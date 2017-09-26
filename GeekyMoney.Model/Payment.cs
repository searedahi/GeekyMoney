﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Model
{
    public class Payment : IPayment
    {
        public decimal Principle { get; set; }
        public decimal Interest { get; set; }
        public decimal Total { get; set; }
    }
}
