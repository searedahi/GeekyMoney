using System.Collections.Generic;

namespace GeekyMoney.Data.Model
{
    public class BlendedRentalRate : BaseGeekyDataModel
    {
        public virtual IEnumerable<RentalRate> RentalRates { get; set; }
        decimal BlendedRentalAmount { get; set; }
        public int ScheduleTypeID { get; set; }
    }
}
