namespace GeekyMoney.Model
{
    public interface IRealEstateScenario : IBaseGeekyObject
    {
        IMortgage Mortgage { get; set; }
        IRealEstateProperty RealEstateProperty { get; set; }  
        IRentalRate RentalRate { get; set; }
        RealEstateScenarioKPI ScenarioKPI { get; set; } //Make this an interface ASAP
    }
}
