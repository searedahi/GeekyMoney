namespace GeekyMoney.Model
{
    public interface IPayment
    {
        decimal Principle { get; set; }
        decimal Interest { get; set; }
        decimal Total { get; set; }
    }
}
