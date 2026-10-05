using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Account;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {

            var user = new AppUser
            {
                UserName = model.Username,
                Email = model.Email
            };

            var createUserResult = await _userManager.CreateAsync(user, model.Password);

            if (!createUserResult.Succeeded)
            {
                return BadRequest(createUserResult.Errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return BadRequest(roleResult.Errors);
            }

            var token = _tokenService.CreateToken(user);

            return Ok(new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = token
            });

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == model.Username);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = _tokenService.CreateToken(user);

            return Ok(new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = token
            });


        }
    }
}
