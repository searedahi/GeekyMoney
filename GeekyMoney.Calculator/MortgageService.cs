using GeekyMoney.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Calculator
{
    public class MortgageService
    {
        private const int MonthsPerYear = 12;

        private IMortgage _mortgage;

        public MortgageService(IMortgage mortgage)
        {
            _mortgage = mortgage;
            MonthlyPayment = CalculatePayment();
        }

        public decimal MonthlyPayment
        {
            get; private set;
        }

        public List<MonthyPayment> AmortizationSchedule
        {
            get

            {
                var schedule = new List<MonthyPayment>();
                var count = 1;
                var remainingBalance = _mortgage.LoanAmount;

                while (count <= _mortgage.TermInMonths)
                {
                    var payment = new MonthyPayment(remainingBalance, _mortgage.InterestRate, MonthlyPayment);
                    schedule.Add(payment);

                    remainingBalance -= payment.PrinciplePaid;
                    count++;
                }
                return schedule;
            }
        }

        /// <summary>
        /// Calculates the monthy payment amount based on current
        /// settings.
        /// </summary>
        /// <returns>Returns the monthly payment amount</returns>
        public decimal CalculatePayment()
        {
            decimal payment = 0;

            if (_mortgage.TermInMonths > 0)
            {
                if (_mortgage.InterestRate != 0)
                {
                    decimal rate = Convert.ToDecimal((_mortgage.InterestRate / MonthsPerYear) / 100);
                    double ratePlus = Convert.ToDouble(rate + 1);
                    decimal factor = (rate + Convert.ToDecimal(Convert.ToDouble(rate) / (Math.Pow(ratePlus, Convert.ToDouble(_mortgage.TermInMonths)) - 1)));
                    payment = (_mortgage.LoanAmount * factor);
                }
                else payment = (_mortgage.LoanAmount / (decimal)_mortgage.TermInMonths);
            }
            return Math.Round(payment, 2);
        }
    }
}
