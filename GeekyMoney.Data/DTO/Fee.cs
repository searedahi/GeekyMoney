namespace GeekyMoney.Data.DTO
{
    public class Fee : BaseGeekyDto
    {
        public decimal Amount { get; set; }
        public bool IsDeductible { get; set; }
        public int ScheduleTypeID { get; set; }
    }
}
