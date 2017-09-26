using System.Collections.Generic;

namespace GeekyMoney.Data.DTO
{
    public class RealEstateProperty : BaseGeekyDto
    {
        public decimal PropertyValue { get; set; }
        public bool IsMultiUnit { get; set; }
        public IEnumerable<RealEstateProperty> Units { get; set; }
        public IEnumerable<RentalRate> RentSchedules { get; set; }
        public double OccupancyRate { get; set; }
        public decimal PropertyTaxRate { get; set; }
        public decimal PropertyTaxAmount { get; set; }
        public IEnumerable<Fee> PropertyFees { get; set; }
        public decimal AppreciationRate { get; set; }
        public string MLSID { get; set; }
    }
}
