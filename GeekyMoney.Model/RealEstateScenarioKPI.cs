using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Model
{
    public class RealEstateScenarioKPI
    {
        private decimal LoanAmount; //Loan Amount on the books.
        private decimal PropertyRentalIncome; //Expected income 
        private decimal PropertyCost; // The sum of all the monthly fees and expenses. 
        private decimal PropertyPrice; //The purchase price.
        private decimal MarketValue; //The current property value.
        private decimal PropertySqFt;


        public RealEstateScenarioKPI(decimal loanAmount, decimal monthlyIncome, decimal monthlyCost, decimal purchasePrice, decimal marketValue, decimal sqFt)
        {
            LoanAmount = loanAmount;
            PropertyRentalIncome = monthlyIncome;
            PropertyCost = monthlyCost;
            PropertyPrice = purchasePrice;
            MarketValue = marketValue;
            PropertySqFt = sqFt;
        }

        // Gross Rent Multiplier is the ratio of the price of a real estate investment 
        // to its annual rental income before accounting for expenses such as 
        // property taxes, insurance, utilities, etc.
        public decimal GrossRentMultiplier
        {
            get
            {
                return (PropertyPrice / AnnualRentalIncome) / 100; // Convert to percent
            }
        }
        public string GrossRentMultiplierFormatted
        {
            get
            {
                return GrossRentMultiplier.ToString("P");
            }
        }
        public decimal AnnualRentalIncome
        {
            get
            {
                return PropertyRentalIncome * 12; //Need a switch on schedule
            }
        }
        public string AnnualRentalIncomeFormatted
        {
            get
            {
                return AnnualRentalIncome.ToString("C");
            }
        }

        public decimal CostPerSqFt
        {
            get
            {
                return PropertyCost / PropertySqFt;
            }
        }
        public string CostPerSqFtFormatted
        {
            get
            {
                return CostPerSqFt.ToString("C");
            }
        }
        public decimal PricePerSqFt
        {
            get
            {
                return PropertyPrice / PropertySqFt;
            }
        }
        public string PricePerSqFtFormatted
        {
            get
            {
                return PricePerSqFt.ToString("C");
            }
        }
        public decimal MarketValuePerSqFt
        {
            get
            {
                return MarketValue / PropertySqFt;
            }
        }
        public string MarketValuePerSqFtFormatted
        {
            get
            {
                return MarketValuePerSqFt.ToString("C");
            }
        }
        //Per Month
        public decimal RentalRatePerSqFt
        {
            get
            {
                return PropertyRentalIncome / PropertySqFt;
            }
        }
        public string RentalRatePerSqFtFormatted
        {
            get
            {
                return RentalRatePerSqFt.ToString("C");
            }
        }

        public decimal LoanToValueRatio
        {
            get
            {
                return LoanAmount / MarketValue;
            }
        }
        public string LoanToValueRatioFormatted
        {
            get
            {
                return LoanToValueRatio.ToString("P");
            }
        }
        // Per square foot.
        // The ratio of the cost per sq/ft to the value per sq/ft
        public decimal CostToValueRatio
        {
            get
            {
                return CostPerSqFt / MarketValuePerSqFt;
            }
        }
        public string CostToValueRatioFormatted
        {
            get
            {
                return CostToValueRatio.ToString("P");
            }
        }

        // Per square foot.
        // The ratio of the price per sq/ft to the value per sq/ft
        public decimal PriceToValueRatio
        {
            get
            {
                return PricePerSqFt / MarketValuePerSqFt;
            }
        }
        public string PriceToValueRatioFormatted
        {
            get
            {
                return PriceToValueRatio.ToString("P");
            }
        }




        // Annually.
        // Cash-on-cash return is a rate of return often used in real estate transactions that 
        // calculates the cash income earned on the cash invested in a property. 
        // For example, when an investor purchases a rental property, she might put down only 10% for a cash down payment. 
        // Cash-on-cash return measures the annual return the investor made on the property in relation to the down payment only.
        // Read more: Cash-On-Cash Return http://www.investopedia.com/terms/c/cashoncashreturn.asp#ixzz4tjcgU8kd 
        public decimal CashOnCashReturn
        {
            get
            {
                return (PropertyRentalIncome * 12) / (LoanAmount - MarketValuePerSqFt);
            }
        }
        public string CashOnCashReturnFormatted
        {
            get
            {
                return CashOnCashReturn.ToString("P");
            }
        }
    }
}