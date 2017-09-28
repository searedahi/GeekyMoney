﻿using System;

namespace GeekyMoney.Model
{
    public interface IBaseGeekyObject
    {
        Guid ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}