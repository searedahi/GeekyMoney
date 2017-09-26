using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Model
{
    public interface IMortgage : IBaseGeekyObject
    {
        decimal PrincipleAmount { get; set; }
        decimal DownPayment { get; set; }
        // Calculated as PrinicipleAmount - DownPayment
        decimal LoanAmount { get; set; }
        // The term of the loan in months
        double Term { get; set; }
        decimal InterestRate { get; set; }
        IEnumerable<IFee> LoanFees { get; set; }

        // Calculated using the PaymentService
        decimal MonthlyPayment { get; }
        IEnumerable<IPayment> AmortizationSchedule { get; }
    }
}
