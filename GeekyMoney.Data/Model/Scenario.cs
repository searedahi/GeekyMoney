using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Data.Model
{
    public class Scenario : BaseGeekyDataModel
    {
        RealEstateProperty RealEstateProperty { get; set; }
        Mortgage Mortgage { get; set; }
        RentalRate RentalRate { get; set; }
    }
}