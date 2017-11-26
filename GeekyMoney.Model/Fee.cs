using GeekyMoney.Enums;

namespace GeekyMoney.Model
{
    public class Fee : IFee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsDeductible { get; set; }
        public int ScheduleTypeID { get; set; }
        public int FeeTypeID { get; set; }
        

        public virtual int? RealEstatePropertyID { get; set; }
        public virtual int? MortgageID { get; set; }

        public ScheduleType ScheduleType { get; set; }
        public FeeType FeeType { get; set; }

        public decimal MonthlyTotal { get; set; }
        public decimal AnnualTotal { get; set; }


    }
}
