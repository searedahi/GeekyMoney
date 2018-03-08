namespace GeekyMoney.Model
{
    public class PercentOfOption
    {
        public PercentOfOption(int i, decimal val, string key, string displayAs)
        {
            Id = i;
            Value = val;
            Name = key;
            DisplayAs = displayAs;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string DisplayAs { get; set; }

    }
}
