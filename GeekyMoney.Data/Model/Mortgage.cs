using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Data.Model
{
    public class Mortgage : BaseGeekyDataModel
    {
        public decimal PrincipleAmount { get; set; }
        public decimal DownPayment { get; set; }
        public double TermInYears { get; set; }
        public double TermInMonths { get; set; }
        public decimal InterestRate { get; set; }
        public decimal LoanAmount { get; set; }        
        public decimal MonthlyPayment { get; }
        public decimal CashToClose { get; }

        public virtual IEnumerable<Fee> LoanFees { get; set; }
    }
}