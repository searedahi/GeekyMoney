namespace GeekyMoney.Model
{
    public interface IRealEstateScenarioKPI
    {
        decimal GrossRentMultiplier { get; }
        string GrossRentMultiplierFormatted { get; }
        decimal MonthlyRentalIncome { get; }
        string MonthlyRentalIncomeFormatted { get; }
        decimal AnnualRentalIncome { get; }
        string AnnualRentalIncomeFormatted { get; }
        decimal CostPerSqFt { get; }
        string CostPerSqFtFormatted { get; }
        decimal PricePerSqFt { get; }
        string PricePerSqFtFormatted { get; }
        decimal MarketValuePerSqFt { get; }
        string MarketValuePerSqFtFormatted { get; }
        //Per Month
        decimal RentalRatePerSqFt { get; }
        string RentalRatePerSqFtFormatted { get; }
        decimal LoanToValueRatio { get; }
        string LoanToValueRatioFormatted { get; }
        // Per square foot.
        // The ratio of the cost per sq/ft to the value per sq/ft
        decimal CostToValueRatio { get; }
        string CostToValueRatioFormatted { get; }

        // Per square foot.
        // The ratio of the price per sq/ft to the value per sq/ft
        decimal PriceToValueRatio { get; }
        string PriceToValueRatioFormatted { get; }

        // Annually.
        // Cash-on-cash return is a rate of return often used in real estate transactions that 
        // calculates the cash income earned on the cash invested in a property. 
        // For example, when an investor purchases a rental property, she might put down only 10% for a cash down payment. 
        // Cash-on-cash return measures the annual return the investor made on the property in relation to the down payment only.
        // Read more: Cash-On-Cash Return http://www.investopedia.com/terms/c/cashoncashreturn.asp#ixzz4tjcgU8kd 
        decimal CashOnCashReturn { get; }
        string CashOnCashReturnFormatted { get; }


    }
}
