using JuanBosch.App.Models.Users;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JuanBosch.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser 
            {
                UserName = model.UserName, 
                Email = model.Email, 
                FirstName = model.FirstName, 
                LastName = model.LastName 
            };

            var result = await _userService.RegisterUserAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "User registered successfully" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        // Accept JSON payloads
        [AllowAnonymous]
        [HttpPost("login")]
        [Consumes("application/json")]
        public async Task<IActionResult> LoginJson([FromBody] LoginModel model)
            => await LoginCore(model);

        // Accept x-www-form-urlencoded payloads (e.g., NextAuth Credentials provider)
        [AllowAnonymous]
        [HttpPost("login")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> LoginForm([FromForm] LoginModel model)
            => await LoginCore(model);

        private async Task<IActionResult> LoginCore(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.FindUserByUserNameAsync(model.UserName);
            // Fallback: if "userName" actually contains an email, try email lookup
            if (user == null && !string.IsNullOrWhiteSpace(model.UserName) && model.UserName.Contains("@"))
            {
                user = await _userService.FindUserByEmailAsync(model.UserName);
            }

            if (user != null && await _userService.CheckPasswordAsync(user, model.Password))
            {
                return Ok(new { token = await _tokenService.CreateToken(user) });
            }

            return Unauthorized(new { message = "Invalid credentials" });
        }
    }

    public class RegisterModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
