namespace GeekyMoney.Data.Model
{
    public class Fee : BaseGeekyDataModel
    {
        public decimal Amount { get; set; }
        public bool IsDeductible { get; set; }
        public int ScheduleTypeID { get; set; }
    }
}
