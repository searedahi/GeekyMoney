namespace GeekyMoney.Model
{
    public interface IFee: IBaseGeekyObject
    {
        decimal Amount { get; set; }
        bool IsDeductible { get; set; }
        ScheduleType Schedule { get; set; }
        FeeType FeeType { get; set; }
        bool IsTemplate { get; set; }
        
        int? RealEstatePropertyID { get; set; }
        int? MortgageID { get; set; }
    }
}
