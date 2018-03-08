using System.Collections.Generic;

namespace GeekyMoney.Model
{
    public interface IScenario : IBaseGeekyObject
    {
        IEnumerable<IMortgage> Mortgages { get; set; }
        IEnumerable<IRealEstateProperty> RealEstateProperties { get; set; }
        IBlendedRentalRate BlendedRentalRate { get; set; }
        IRealEstateScenarioKPI ScenarioKPI { get; set; }
    }
}
