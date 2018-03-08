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
        public string PercentBasedOn { get; set; }
        public string ParentClass { get; set; }

        public virtual int? RealEstatePropertyID { get; set; }
        public virtual int? MortgageID { get; set; }

        public ScheduleType ScheduleType { get; set; }
        public FeeType FeeType { get; set; }

        public decimal MonthlyTotal
        {
            get
            {
                var monthlyAmount = 0M;

                if (FeeTypeID == 2)
                {
                    monthlyAmount = Amount * (PercentRate / 100);
                }
                else
                {
                    monthlyAmount = Amount;
                }

                switch (ScheduleTypeID)
                {
                    case 1:
                        monthlyAmount = monthlyAmount / 12;
                        break;
                    case 2:
                        monthlyAmount = (monthlyAmount * 365) / 12;
                        break;
                    case 3:
                        monthlyAmount = (monthlyAmount * 52) / 12;
                        break;
                    case 4:
                        monthlyAmount = (monthlyAmount * 26) / 12;
                        break;
                    case 6:
                        monthlyAmount = monthlyAmount / 2;
                        break;
                    case 7:
                        monthlyAmount = monthlyAmount / 3;
                        break;
                    case 8:
                        monthlyAmount = monthlyAmount / 12;
                        break;
                    default:
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
