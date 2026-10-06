using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio?> DeleteAsync(AppUser user, string symbol)
        {
            var portfolio = await _context.Portfolios.FirstOrDefaultAsync(p => p.AppUserId == user.Id && p.Stock.Symbol.ToUpper() == symbol.ToUpper());
            if (portfolio == null)
            {
                return null;
            }
            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<List<Stock>> GetUserPortfolioAsync(AppUser user)
        {
            return await _context.Portfolios.Where(s => s.AppUserId == user.Id).Select(s => new Stock
            {
                Id = s.StockId,
                Symbol = s.Stock.Symbol,
                CompanyName = s.Stock.CompanyName,
                Purchase = s.Stock.Purchase,
                lastDividend = s.Stock.lastDividend,
                Industry = s.Stock.Industry,
                marketCap = s.Stock.marketCap,
            }).ToListAsync();

        }
    }
}
