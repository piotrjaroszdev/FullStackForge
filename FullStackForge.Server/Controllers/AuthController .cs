using FullStackForge.Server.DTOs;
using FullStackForge.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FullStackForge.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDto registerCredentials)
        {
            try
            {
                var token = await _authService.RegisterAsync(registerCredentials.Username, registerCredentials.Password);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserDto loginCredentials)
        {
            try
            {
                var token = await _authService.LoginAsync(loginCredentials.Username, loginCredentials.Password);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpGet("test")]
        public async Task<IActionResult> test()
        {
            // ten endpoint wymaga ważnego tokena (brak [AllowAnonymous])
            return Ok();
        }
    }
}
