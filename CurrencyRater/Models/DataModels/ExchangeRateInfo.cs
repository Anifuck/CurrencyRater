namespace CurrencyRater.Models
{
    public class ExchangeRateInfo
    {
        public string ID { get; set; }
        public string NumCode { get; set; }
        public string CharCode { get; set; }
        public string Name { get; set; }
        public long Nominal { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; }
    }
}
