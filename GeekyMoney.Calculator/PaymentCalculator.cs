using System;
using GeekyMoney.Model;

namespace GeekyMoney.Calculator
{
    public class PaymentCalculator
    {
        private const int MonthsPerYear = 12;

        public decimal LoanAmount { get; private set; }
        public decimal InterestRate { get; private set; }
        public double LoanTermInMonths { get; private set; }

        //public decimal InterestPaid { get; private set; }
        //public decimal PrinciplePaid { get; private set; }
        //public decimal TaxesPaid { get; private set; }

        public PaymentCalculator(decimal loanAmount, decimal interestRate, double loanTerm)
        {
            LoanAmount = loanAmount;
            InterestRate = interestRate;
            LoanTermInMonths = loanTerm;
        }


        /// <summary>
        /// Calculates the monthy payment amount based on current
        /// settings.
        /// </summary>
        /// <returns>Returns the monthly payment amount</returns>
        public IPayment CalculateMonthlyPayment()
        {
            decimal paymentAmount = 0;

            if (LoanTermInMonths > 0)
            {
                if (InterestRate != 0)
                {
                    decimal rate = ((InterestRate / MonthsPerYear) / 100);
                    double ratePlus = Convert.ToDouble(rate + 1); //Revist the castings here.   Questionable shit here..
                    decimal factor = (rate + (rate / Convert.ToDecimal(Math.Pow(ratePlus, LoanTermInMonths) - 1)));

                    paymentAmount = (LoanAmount * factor);
                }
                else paymentAmount = (LoanAmount / (decimal)LoanTermInMonths);
            }
            var monthlyPayment = Math.Round(paymentAmount, 2);

            var payment = new Payment
            {
                Total = monthlyPayment
            };

            payment.Interest = monthlyPayment * (InterestRate / MonthsPerYear);
            payment.Principle = monthlyPayment - payment.Interest;

            return payment;
        }



    }
}
