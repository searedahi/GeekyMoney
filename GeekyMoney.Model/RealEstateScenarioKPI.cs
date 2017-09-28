﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Model
{
    public class RealEstateScenarioKPI
    {
        private IRealEstateScenario _scenario;


        public RealEstateScenarioKPI(IRealEstateScenario scenario)
        {
            _scenario = scenario;
        }

        // Gross Rent Multiplier is the ratio of the price of a real estate investment 
        // to its annual rental income before accounting for expenses such as 
        // property taxes, insurance, utilities, etc.
        public decimal GrossRentMultiplier
        {
            get
            {
                return (_scenario.RealEstateProperty.PurchasePrice / AnnualRentalIncome) / 100; // Convert to percent
            }
        }

        public string GrossRentMultiplierFormatted
        {
            get
            {
                return GrossRentMultiplier.ToString("P");
            }
        }

        public decimal MonthlyRentalIncome
        {
            get
            {
                return _scenario.RentalRate.RentalAmount * 12;
            }
        }

        public string MonthlyRentalIncomeFormatted
        {
            get
            {
                return MonthlyRentalIncome.ToString("C");
            }
        }

        public decimal AnnualRentalIncome
        {
            get
            {
                return MonthlyRentalIncome * 12;
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
                return _scenario.RealEstateProperty.TotalMonthlyCost / _scenario.RealEstateProperty.SqFt;
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
                return _scenario.RealEstateProperty.PurchasePrice / _scenario.RealEstateProperty.SqFt;
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
                return _scenario.RealEstateProperty.MarketValue / _scenario.RealEstateProperty.SqFt;
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
                return MonthlyRentalIncome / _scenario.RealEstateProperty.SqFt;
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
                return _scenario.Mortgage.LoanAmount / _scenario.RealEstateProperty.MarketValue;
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
                return AnnualRentalIncome/ (_scenario.Mortgage.DownPayment + _scenario.Mortgage.CashToClose);
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