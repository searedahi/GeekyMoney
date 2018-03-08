using GeekyMoney.Enums;
using System;

namespace GeekyMoney.Model
{
    public interface IRentalRate
    {
        decimal RentalAmount { get; set; }
        ScheduleType Schedule { get; set; }
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        decimal AnnualWeight { get; }
    }
}
