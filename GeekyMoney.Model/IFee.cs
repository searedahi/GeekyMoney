namespace GeekyMoney.Model
{
    public interface IFee: IBaseGeekyObject
    {
        decimal Amount { get; set; }
        bool IsDeductible { get; set; }
        //ScheduleType Schedule { get; set; }
    }
}
