﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Model
{
    public class Fee : IFee
    {
        public decimal Amount { get; set; }
        public bool IsDeductible { get; set; }
        public ScheduleType Schedule { get; set; }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}