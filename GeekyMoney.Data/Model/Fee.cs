using GeekyMoney.Enums;

namespace GeekyMoney.Data.Model
{
    public class Fee : BaseGeekyDataModel
    {
        public decimal Amount { get; set; }
        public bool IsDeductible { get; set; }
        public int ScheduleTypeID { get; set; }
        public int FeeTypeID { get; set; }
        public bool IsTemplate { get; set; }

        public virtual int? RealEstatePropertyID { get; set; }
        public virtual int? MortgageID { get; set; }
    }
}
