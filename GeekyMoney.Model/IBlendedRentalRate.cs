using GeekyMoney.Enums;
using System.Collections.Generic;

namespace GeekyMoney.Model
{
    public interface IBlendedRentalRate
    {
        IEnumerable<IRentalRate> RentalRates { get; set; }
        decimal BlendedRentalAmount { get; set; }
        ScheduleType Schedule { get; set; }
    }
}
