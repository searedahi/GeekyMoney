namespace GeekyMoney.Data.Model
{
    public class RentalRate : BaseGeekyDataModel
    {
        public decimal RentalAmount { get; set; }
        public int ScheduleTypeID { get; set; }
    }
}
