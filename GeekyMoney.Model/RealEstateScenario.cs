using System;
using System.Collections.Generic;
using System.Text;

namespace GeekyMoney.Model
{
    public class RealEstateScenario : IRealEstateScenario
    {
        public IMortgage Mortgage { get; set; }
        public IRealEstateProperty RealEstateProperty { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IRentalRate RentalRate { get; set; }
        public RealEstateScenarioKPI ScenarioKPI { get; set; }

        private decimal ExpectedIncome; //Expected income 

        public RealEstateScenario(bool isFakeConstructorFOrSpeed)
        {
            Mortgage = new Mortgage();
            RealEstateProperty = new RealEstateProperty();
        }
    }
}
