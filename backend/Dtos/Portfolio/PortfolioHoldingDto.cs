namespace backend.Dtos.Portfolio
{
    public class PortfolioHoldingDto
    {
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public decimal Shares { get; set; }
        public decimal AvgCost { get; set; }
        public DateTime? PurchasedOn { get; set; }
        public decimal CostBasis { get; set; }

        // Live quote values are null when FMP has no price for the symbol
        public decimal? Price { get; set; }
        public decimal? Change { get; set; }
        public decimal? ChangePercentage { get; set; }
        public decimal? MarketValue { get; set; }
        public decimal? DayChange { get; set; }
        public decimal? GainLoss { get; set; }
        public decimal? GainLossPercentage { get; set; }
    }
}
