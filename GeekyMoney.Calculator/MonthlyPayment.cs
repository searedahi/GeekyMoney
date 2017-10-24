namespace GeekyMoney.Calculator
{
    public class MonthyPayment
    {
        private decimal _interestAsDecimal;
        public decimal PrincipleBalance { get; private set; }
        public decimal InterestRate { get; private set; }
        public decimal PaymentAmount { get; private set; }

        public decimal InterestPaid
        {
            get
            {
                return PrincipleBalance * _interestAsDecimal;
            }
        }
        public decimal PrinciplePaid
        {
            get
            {
                return PaymentAmount - InterestPaid;
            }
        }
        public decimal PrincipleBalanceAfterPayment
        {
            get
            {

                return PrincipleBalance - PrinciplePaid;
            }
        }

        public MonthyPayment(decimal principle, decimal interest, decimal paymentAmount)
        {
            PrincipleBalance = principle;
            InterestRate = interest;
            PaymentAmount = paymentAmount;

            _interestAsDecimal = InterestRate / 1200;  //divide by 100 for percent then divide by twelve for each month in the annual rate
        }
    }

}
