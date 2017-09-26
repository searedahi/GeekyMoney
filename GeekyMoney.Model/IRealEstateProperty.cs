using System.Collections.Generic;

namespace GeekyMoney.Model
{
    public interface IRealEstateProperty:IBaseGeekyObject
    {
        decimal PropertyValue { get; set; }
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
