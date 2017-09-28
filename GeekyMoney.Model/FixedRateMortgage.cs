using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeekyMoney.Model
{
    public class FixedRateMortgage : IMortgage
    {
        public decimal PrincipleAmount { get; set; }
        public decimal DownPayment { get; set; }
        public decimal LoanAmount { get; set; }
        public double Term { get; set; }
        public decimal InterestRate { get; set; }
        public IEnumerable<IFee> LoanFees { get; set; }

        public decimal MonthlyPayment => throw new NotImplementedException();

        public IEnumerable<IPayment> AmortizationSchedule => throw new NotImplementedException();

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal CashToClose
        {
            get
            {
                decimal cashNeeded = LoanFees.Sum(l => l.Amount);
                return cashNeeded;
            }
        }
    }
}
