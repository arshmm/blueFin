using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.Stock;
using backend.Helpers;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _db;
        public StockRepository(ApplicationDBContext context)
        {
            _db = context;
        }
        public Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _db.Stocks.Include(s => s.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if (string.Equals(query.SortBy, "CompanyName", StringComparison.OrdinalIgnoreCase))
            {
                stocks = query.IsDescending ? stocks.OrderByDescending(s => s.CompanyName).ThenBy(s => s.Id) : stocks.OrderBy(s => s.CompanyName).ThenBy(s => s.Id);
            }
            else if (string.Equals(query.SortBy, "Symbol", StringComparison.OrdinalIgnoreCase))
            {
                stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol).ThenBy(s => s.Id) : stocks.OrderBy(s => s.Symbol).ThenBy(s => s.Id);
            }
            else
            {
                stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Id) : stocks.OrderBy(s => s.Id);
            }

            var skip = (query.PageNumber - 1) * query.PageSize;

            return stocks.Skip(skip).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _db.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _db.Stocks.AddAsync(stock);
            await _db.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stock)
        {
            var stockModel = await _db.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            stockModel.Symbol = stock.Symbol;
            stockModel.CompanyName = stock.CompanyName;
            stockModel.Purchase = stock.Purchase;
            stockModel.lastDividend = stock.lastDividend!.Value;
            stockModel.Industry = stock.Industry;
            stockModel.marketCap = stock.marketCap;

            await _db.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _db.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            _db.Stocks.Remove(stockModel);
            await _db.SaveChangesAsync();

            return stockModel;
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _db.Stocks.AnyAsync(s => s.Id == id);
        }
    }
}