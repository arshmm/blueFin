using backend.Dtos.Portfolio;
using backend.Extensions;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PortfolioController : ControllerBase
    {
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IPortfolioRepository _portfolioRepo;

        private readonly IFMPService _fmpService;

        public PortfolioController(IStockRepository stockRepo, UserManager<AppUser> userManager, IPortfolioRepository portfolioRepository, IFMPService fmpService)
        {
            _stockRepo = stockRepo;
            _userManager = userManager;
            _portfolioRepo = portfolioRepository;
            _fmpService = fmpService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return Unauthorized();
            }

            var portfolio = await _portfolioRepo.GetUserPortfolioAsync(user);
            var quotes = await Task.WhenAll(portfolio.Select(p => _fmpService.GetQuoteAsync(p.Stock.Symbol)));
            var holdings = portfolio.Select((p, i) => p.ToHoldingDto(quotes[i])).ToList();

            return Ok(holdings);


        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio([FromBody] CreatePortfolioRequestDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var symbol = createDto.Symbol;
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return Unauthorized();
            }

            var stock = await _stockRepo.GetBySymbolAsync(symbol.ToUpper());
            if (stock == null)
            {
                stock = await _fmpService.FindStockBySymbolAsync(symbol.ToUpper());
                if (stock == null)
                {
                    return NotFound("Stock not found.");
                }
                else
                {
                    await _stockRepo.CreateAsync(stock);
                }
            }

            var existingHolding = await _portfolioRepo.GetUserHoldingAsync(user, stock.Symbol);

            if (existingHolding != null)
            {
                return BadRequest("Stock already in portfolio. Edit the holding to change shares.");
            }

            var quote = await _fmpService.GetQuoteAsync(stock.Symbol);
            var avgCost = createDto.AvgCost ?? quote?.price;

            if (avgCost == null)
            {
                return BadRequest("No live price available. Enter your average cost.");
            }

            var portfolio = new Portfolio
            {
                AppUserId = user.Id,
                StockId = stock.Id,
                Shares = createDto.Shares,
                AvgCost = Math.Round(avgCost.Value, 2),
                PurchasedOn = createDto.PurchasedOn,
                Stock = stock
            };

            await _portfolioRepo.CreateAsync(portfolio);
            return Created($"api/portfolio/{stock.Symbol}", portfolio.ToHoldingDto(quote));

        }

        [HttpPut("{symbol}")]
        public async Task<IActionResult> UpdatePortfolio([FromRoute] string symbol, [FromBody] UpdatePortfolioRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return Unauthorized();
            }

            var portfolio = await _portfolioRepo.UpdateAsync(user, symbol, updateDto);

            if (portfolio == null)
            {
                return NotFound("Stock not found in portfolio.");
            }

            var quote = await _fmpService.GetQuoteAsync(portfolio.Stock.Symbol);
            return Ok(portfolio.ToHoldingDto(quote));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return Unauthorized();
            }

            var portfolio = await _portfolioRepo.DeleteAsync(user, symbol.ToUpper());

            if (portfolio == null)
            {
                return NotFound("Stock not found in portfolio.");
            }

            return NoContent();
        }
    }
}