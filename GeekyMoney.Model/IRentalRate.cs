using GeekyMoney.Enums;

namespace GeekyMoney.Model
{
    public interface IRentalRate
    {
        decimal RentalAmount { get; set; }
        ScheduleType Schedule { get; set; }
    }
}
