using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Model
{
    public class RealEstateProperty : BaseGeekyDataModel
    {
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

        public virtual IEnumerable<Fee> PropertyFees { get; set; }
        //public virtual IEnumerable<RealEstateProperty> Units { get; set; }
        //public virtual IEnumerable<RentalRate> RentSchedules { get; set; }
    }
}
