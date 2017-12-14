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
        public decimal PercentRate { get; set; }
        public decimal PercentBaseValue { get; set; }
        public string PercentBasedOn { get; set; }


        public virtual int? RealEstatePropertyID { get; set; }
        public virtual int? MortgageID { get; set; }

        public ScheduleType ScheduleType { get; set; }
        public FeeType FeeType { get; set; }

        public decimal MonthlyTotal
        {
            get
            {
                var monthlyAmount = 0M;

                switch (ScheduleTypeID)
                {
                    case 1:
                        monthlyAmount = Amount / 12;
                        break;
                    case 2:
                        monthlyAmount = (Amount * 365) / 12;
                        break;
                    case 3:
                        monthlyAmount = (Amount * 52) / 12;
                        break;
                    case 4:
                        monthlyAmount = (Amount * 26) / 12;
                        break;
                    case 5:
                        monthlyAmount = Amount;
                        break;
                    case 6:
                        monthlyAmount = Amount / 2;
                        break;
                    case 7:
                        monthlyAmount = Amount / 3;
                        break;
                    case 8:
                        monthlyAmount = Amount / 12;
                        break;
                    default:
                        monthlyAmount = Amount;
                        break;
                }

                return monthlyAmount;
            }
        }

        public decimal AnnualTotal
        {
            get
            {
                return MonthlyTotal * 12;
            }
        }

    }
}
