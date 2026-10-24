using backend.Dtos.Portfolio;
using backend.Dtos.Stock;
using backend.Models;

namespace backend.Mappers
{
    public static class PortfolioMappers
    {
        public static PortfolioHoldingDto ToHoldingDto(this Portfolio portfolio, FMPQuote? quote)
        {
            var costBasis = portfolio.Shares * portfolio.AvgCost;

            var holding = new PortfolioHoldingDto
            {
                Symbol = portfolio.Stock.Symbol,
                CompanyName = portfolio.Stock.CompanyName,
                Industry = portfolio.Stock.Industry,
                Shares = portfolio.Shares,
                AvgCost = portfolio.AvgCost,
                PurchasedOn = portfolio.PurchasedOn,
                CostBasis = Math.Round(costBasis, 2)
            };

            if (quote == null)
            {
                return holding;
            }

            var marketValue = portfolio.Shares * quote.price;

            holding.Price = quote.price;
            holding.Change = quote.change;
            holding.ChangePercentage = quote.changePercentage;
            holding.MarketValue = Math.Round(marketValue, 2);
            holding.DayChange = Math.Round(portfolio.Shares * quote.change, 2);
            holding.GainLoss = Math.Round(marketValue - costBasis, 2);
            holding.GainLossPercentage = costBasis > 0 ? Math.Round((marketValue - costBasis) / costBasis * 100, 2) : null;

            return holding;
        }
    }
}
