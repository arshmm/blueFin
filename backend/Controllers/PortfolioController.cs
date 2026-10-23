using backend.Extensions;
using backend.Interfaces;
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
            return Ok(portfolio);


        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
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

            var userPortfolio = await _portfolioRepo.GetUserPortfolioAsync(user);

            if (userPortfolio.Any(p => p.Symbol.ToUpper() == stock.Symbol.ToUpper()))
            {
                return BadRequest("Stock already in portfolio.");
            }

            var portfolio = new Portfolio
            {
                AppUserId = user.Id,
                StockId = stock.Id
            };

            await _portfolioRepo.CreateAsync(portfolio);
            if (portfolio == null)
            {
                return BadRequest("Failed to add stock to portfolio.");
            }
            return Created();

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