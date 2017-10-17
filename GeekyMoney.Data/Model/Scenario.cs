using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Data.Model
{
    public class Scenario : BaseGeekyDataModel
    {
        public RealEstateProperty RealEstateProperty { get; set; }
        public Mortgage Mortgage { get; set; }
        public RentalRate RentalRate { get; set; }
    }
}