using System.Collections.Generic;

namespace GeekyMoney.Model
{
    public class Scenario : IScenario
    {
        public virtual IEnumerable<IMortgage> Mortgages { get; set; }
        public virtual IEnumerable<IRealEstateProperty> RealEstateProperties { get; set; }
        public virtual IEnumerable<IRentalRate> RentalRates { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IRealEstateScenarioKPI ScenarioKPI { get; set; }
        public IBlendedRentalRate BlendedRentalRate { get; set; }

        private decimal ExpectedIncome; //Expected income

        public Scenario(bool isFakeConstructorForSpeed)
        {
            Mortgages = new List<IMortgage>();
            RealEstateProperties = new List<IRealEstateProperty>();
            RentalRates = new List<IRentalRate>();
        }
        public Scenario() { }
    }
}
