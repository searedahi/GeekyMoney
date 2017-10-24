using System.Collections.Generic;

namespace GeekyMoney.Model
{
    public class Mortgage : IMortgage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal PrincipleAmount { get; set; }
        public decimal DownPayment { get; set; }
        public decimal LoanAmount { get; set; }
        public double TermInMonths { get; set; }
        public double TermInYears { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MonthlyPayment { get; private set; }

        public IEnumerable<IFee> LoanFees { get; set; }
        public IEnumerable<IPayment> AmortizationSchedule { get; private set; }

        public decimal CashToClose { get; private set; }
        //public decimal CashToClose
        //{
        //    get
        //    {
        //        decimal cashNeeded = LoanFees.Sum(l => l.Amount);
        //        return cashNeeded;
        //    }
        //}


    }
}
