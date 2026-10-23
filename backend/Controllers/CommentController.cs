using backend.Dtos.Comment;
using backend.Extensions;
using backend.Helpers;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _userManager;

        private readonly IFMPService _fmpService;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository, UserManager<AppUser> userManager, IFMPService fmpService)
        {
            _commentRepo = commentRepository;
            _stockRepo = stockRepository;
            _userManager = userManager;
            _fmpService = fmpService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] CommentQueryObject query)
        {
            var comment = await _commentRepo.GetAllAsync(query);
            var commentDto = comment.Select(s => s.ToCommentDto()).ToList();

            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{symbol:alpha}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] string symbol, CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return Unauthorized();
            }
            var commentModel = commentDto.ToCommentFromCreate(stock.Id);

            commentModel.AppUserId = user.Id;
            var createdComment = await _commentRepo.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = createdComment.Id }, createdComment.ToCommentDto());

        }
        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingComment = await _commentRepo.GetByIdAsync(id);

            if (existingComment == null)
            {
                return NotFound("Comment not found");
            }

            if (!await CanModifyAsync(existingComment))
            {
                return Forbid();
            }

            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdate(id));

            if (comment == null)
            {
                return NotFound("Comment not found");
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingComment = await _commentRepo.GetByIdAsync(id);

            if (existingComment == null)
            {
                return NotFound("Comment does not exist.");
            }

            if (!await CanModifyAsync(existingComment))
            {
                return Forbid();
            }

            var commentModel = await _commentRepo.DeleteAsync(id);

            if (commentModel == null)
            {
                return NotFound("Comment does not exist.");
            }

            return Ok(commentModel.ToCommentDto());
        }

        private async Task<bool> CanModifyAsync(Comment comment)
        {
            if (User.IsInRole("Admin"))
            {
                return true;
            }

            var user = await _userManager.FindByNameAsync(User.GetUsername());
            return user != null && comment.AppUserId == user.Id;
        }
    }
}