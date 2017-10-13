using System;
using System.Collections.Generic;

namespace GeekyMoney.Model
{
    public interface IRealEstateProperty : IBaseGeekyObject
    {
        decimal AskingPrice { get; set; }

        // The current market value as we see it.
        // ie "If we sold this..."
        decimal MarketValue { get; set; }
        
        // The purchase price we would/did pay.
        decimal PurchasePrice { get; set; }

        // The square footage of the property.
        decimal SquareFeet { get; set; }
        
        // The sum of all the monthly fees and expenses. 
        // The set will be deprecated.  DONT USE!!!
        decimal TotalMonthlyCost { get; set; }

        bool IsMultiUnit { get; set; }
        double OccupancyRate { get; set; }
        decimal PropertyTaxRate { get; set; }
        decimal PropertyTaxAmount { get; set; }
        decimal AppreciationRate { get; set; }
        string Address { get; set; }
        DateTime Listed { get; set; }
        DateTime Created { get; set; }
        DateTime Built { get; set; }
        string MLSID { get; set; }
        string ZillowId { get; set; }
        string RedFinId { get; set; }
        string TruliaId { get; set; }

        IEnumerable<Fee> PropertyFees { get; set; }
        //IEnumerable<IRealEstateProperty> Units { get; set; }
        //IEnumerable<IRentalRate> RentSchedules { get; set; }

    }
}
