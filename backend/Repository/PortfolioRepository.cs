using backend.Data;
using backend.Dtos.Portfolio;
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

        public async Task<List<Portfolio>> GetUserPortfolioAsync(AppUser user)
        {
            return await _context.Portfolios.Include(p => p.Stock).Where(p => p.AppUserId == user.Id).ToListAsync();
        }

        public async Task<Portfolio?> GetUserHoldingAsync(AppUser user, string symbol)
        {
            return await _context.Portfolios.Include(p => p.Stock).FirstOrDefaultAsync(p => p.AppUserId == user.Id && p.Stock.Symbol.ToUpper() == symbol.ToUpper());
        }

        public async Task<Portfolio?> UpdateAsync(AppUser user, string symbol, UpdatePortfolioRequestDto updateDto)
        {
            var portfolio = await GetUserHoldingAsync(user, symbol);
            if (portfolio == null)
            {
                return null;
            }

            portfolio.Shares = updateDto.Shares;
            portfolio.AvgCost = updateDto.AvgCost;
            portfolio.PurchasedOn = updateDto.PurchasedOn;

            await _context.SaveChangesAsync();
            return portfolio;
        }
    }
}
