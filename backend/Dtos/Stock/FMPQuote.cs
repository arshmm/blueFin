namespace backend.Dtos.Stock
{
    public class FMPQuote
    {
        public string symbol { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public decimal price { get; set; }
        public decimal changePercentage { get; set; }
        public decimal change { get; set; }
        public long volume { get; set; }
        public decimal dayLow { get; set; }
        public decimal dayHigh { get; set; }
        public decimal yearHigh { get; set; }
        public decimal yearLow { get; set; }
        public long marketCap { get; set; }
        public decimal open { get; set; }
        public decimal previousClose { get; set; }
        public long timestamp { get; set; }
    }
}
