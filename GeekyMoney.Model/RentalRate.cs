using GeekyMoney.Enums;

namespace GeekyMoney.Model
{
    public class RentalRate : IRentalRate
    {
        decimal RentalAmount { get; set; }
        decimal IRentalRate.RentalAmount { get; set; }
        ScheduleType Schedule { get; set; }
        ScheduleType IRentalRate.Schedule { get; set; }
    }
}
