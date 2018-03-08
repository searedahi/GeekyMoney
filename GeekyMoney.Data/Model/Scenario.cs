using System.Collections.Generic;

namespace GeekyMoney.Data.Model
{
    public class Scenario : BaseGeekyDataModel
    {
        public virtual IEnumerable<RealEstateProperty> RealEstateProperties { get; set; }

        public virtual IEnumerable<Mortgage> Mortgages { get; set; }

        public RentalRate RentalRate { get; set; }
    }
}