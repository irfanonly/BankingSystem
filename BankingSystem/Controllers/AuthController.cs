using BankingSystem.Dtos;
using BankingSystem.Interface;
using BankingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserService _userService;

        public AuthController(IJwtTokenService jwtTokenService, IUserService userService)
        {
            _jwtTokenService = jwtTokenService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var user = _userService.GetUserAsync(loginDto);
            if (user != null)
            {
                var token = _jwtTokenService.GenerateToken(loginDto.Username);
                return Ok(new { Token = token });
            }
            return BadRequest("Incorrect username/password");
        }
    }


}
