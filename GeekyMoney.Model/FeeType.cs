using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Model
{
    public class FeeType: IBaseGeekyObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
