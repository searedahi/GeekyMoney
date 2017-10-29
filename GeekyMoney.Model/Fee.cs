namespace GeekyMoney.Model
{
    public class Fee : IFee
    {
        public decimal Amount { get; set; }
        public bool IsDeductible { get; set; }
        public int ScheduleTypeID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ScheduleType Schedule { get; set; }
        public FeeType FeeType { get; set; }
        public bool IsTemplate { get; set; }

        public int? RealEstatePropertyID { get; set; }
        public int? MortgageID { get; set; }

    }
}
