using backend.Dtos.Portfolio;
using backend.Models;

namespace backend.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Portfolio>> GetUserPortfolioAsync(AppUser user);
        Task<Portfolio?> GetUserHoldingAsync(AppUser user, string symbol);
        Task<Portfolio> CreateAsync(Portfolio portfolio);
        Task<Portfolio?> UpdateAsync(AppUser user, string symbol, UpdatePortfolioRequestDto updateDto);
        Task<Portfolio?> DeleteAsync(AppUser user, string symbol);
    }
}
