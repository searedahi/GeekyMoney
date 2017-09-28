using System.Collections.Generic;

namespace GeekyMoney.Model
{
    public interface IRealEstateProperty : IBaseGeekyObject
    {
        // The current market value as we see it.
        // ie "If we sold this..."
        decimal MarketValue { get; set; }


        // The purchase price we would/did pay.
        decimal PurchasePrice { get; set; }

        // The sum of all the monthly fees and expenses. 
        // The set will be deprecated.  DONT USE!!!
        decimal TotalMonthlyCost { get; set; }

        // The square footage of the property.
        decimal SqFt { get; set; }


        bool IsMultiUnit { get; set; }
        IEnumerable<IRealEstateProperty> Units { get; set; }
        IEnumerable<IRentalRate> RentSchedules { get; set; }

        double OccupancyRate { get; set; }
        decimal PropertyTaxRate { get; set; }
        decimal PropertyTaxAmount { get; set; }
        IEnumerable<IFee> PropertyFees { get; set; }
        decimal AppreciationRate { get; set; }
    }
}
