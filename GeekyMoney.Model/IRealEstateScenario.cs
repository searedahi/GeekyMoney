namespace GeekyMoney.Model
{
    public interface IRealEstateScenario : IBaseGeekyObject
    {
        IMortgage Mortgage { get; set; }
        IRealEstateProperty RealEstateProperty { get; set; }
    }
}
