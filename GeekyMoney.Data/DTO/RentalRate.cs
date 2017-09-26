namespace GeekyMoney.Data.DTO
{
    public class RentalRate : BaseGeekyDto
    {
        public decimal RentalAmount { get; set; }
        public int ScheduleTypeID { get; set; }
    }
}
