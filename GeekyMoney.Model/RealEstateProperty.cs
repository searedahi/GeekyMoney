using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Model
{
    public class RealEstateProperty : IRealEstateProperty
    {
        public decimal PurchasePrice { get; set; }
        public bool IsMultiUnit { get; set; }
        public IEnumerable<IRealEstateProperty> Units { get; set; }
        public IEnumerable<IRentalRate> RentSchedules { get; set; }
        public double OccupancyRate { get; set; }
        public decimal PropertyTaxRate { get; set; }
        public decimal PropertyTaxAmount { get; set; }
        public IEnumerable<IFee> PropertyFees { get; set; }
        public decimal AppreciationRate { get; set; }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public decimal MarketValue { get; set; }
        public decimal TotalMonthlyCost { get; set; }
        public decimal PropertyPrice { get; set; }
        public decimal SquareFeet { get; set; }
        public DateTime ListingDate { get; set; }

        public RealEstateProperty()
        {
            Units = new List<IRealEstateProperty>();
            RentSchedules = new List<IRentalRate>();
            PropertyFees = new List<IFee>();
        }

    }
}
