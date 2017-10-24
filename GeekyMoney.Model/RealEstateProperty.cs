using System;
using System.Collections.Generic;

namespace GeekyMoney.Model
{
    public class RealEstateProperty : IRealEstateProperty
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal AskingPrice { get; set; }
        public decimal MarketValue { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SquareFeet { get; set; }
        public bool IsMultiUnit { get; set; }
        public double OccupancyRate { get; set; }
        public decimal PropertyTaxRate { get; set; }
        public decimal PropertyTaxAmount { get; set; }
        public decimal AppreciationRate { get; set; }
        public string Address { get; set; }
        public decimal TotalMonthlyCost { get; set; }
        public DateTime Listed { get; set; }
        public DateTime Created { get; set; }
        public DateTime Built { get; set; }
        public string MLSID { get; set; }
        public string ZillowId { get; set; }
        public string RedFinId { get; set; }
        public string TruliaId { get; set; }

        //public IEnumerable<RealEstateProperty> Units { get; set; }
        //public IEnumerable<IRentalRate> RentSchedules { get; set; }
        public IEnumerable<Fee> PropertyFees { get; set; }


        public RealEstateProperty()
        {
            //Units = new List<RealEstateProperty>();
            //RentSchedules = new List<IRentalRate>();
            PropertyFees = new List<Fee>();
        }

    }
}
