using GeekyMoney.Enums;

namespace GeekyMoney.Model
{
    public interface IFee : IBaseGeekyObject
    {
        decimal Amount { get; set; }
        bool IsDeductible { get; set; }
        bool IsTemplate { get; set; }
        int ScheduleTypeID { get; set; }
        int FeeTypeID { get; set; }

        int? RealEstatePropertyID { get; set; }
        int? MortgageID { get; set; }

        ScheduleType ScheduleType { get; set; }
        FeeType FeeType { get; set; }

        decimal MonthlyTotal { get; }
        decimal AnnualTotal { get; }

        decimal PercentRate { get; set; }
        decimal PercentBaseValue { get; set; }
        string PercentBasedOn { get; set; }
    }
}
