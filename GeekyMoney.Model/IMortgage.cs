using System.Collections.Generic;

namespace GeekyMoney.Model
{
    public interface IMortgage : IBaseGeekyObject
    {
        decimal PrincipleAmount { get; set; }
        decimal CashToClose { get; }

        decimal DownPayment { get; set; }
        // Calculated as PrinicipleAmount - DownPayment
        decimal LoanAmount { get; set; }

        // The term of the loan in years
        double TermInYears { get; set; }

        // The term of the loan in months
        double TermInMonths { get; set; }

        decimal InterestRate { get; set; }

        // Calculated using the PaymentService
        decimal MonthlyPayment { get; }
        IEnumerable<IPayment> AmortizationSchedule { get; }
        IEnumerable<IFee> LoanFees { get; set; }
    }
}