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

        decimal MonthlyTotal { get; set; }
        decimal AnnualTotal { get; set; }

    }
}
