namespace GeekyMoney.Model
{
    public class PercentOfOption
    {
        public PercentOfOption(int i, decimal val, string key)
        {
            Id = i;
            Value = val;
            Name = key;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
