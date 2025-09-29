using JuanBosch.App.Models.Users;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace JuanBosch.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
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

        // Unified login to support both JSON and x-www-form-urlencoded payloads
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            var model = new LoginModel();

            try
            {
                if (Request.HasFormContentType)
                {
                    var form = await Request.ReadFormAsync();
                    model.UserName = form["userName"].ToString() ?? form["username"].ToString();
                    if (string.IsNullOrWhiteSpace(model.UserName) && form.ContainsKey("email"))
                    {
                        model.UserName = form["email"].ToString();
                    }
                    model.Password = form["password"].ToString();
                }
                else
                {
                    using var reader = new StreamReader(Request.Body);
                    var body = await reader.ReadToEndAsync();
                    if (!string.IsNullOrWhiteSpace(body))
                    {
                        var trimmed = body.TrimStart();
                        var parsed = (LoginModel)null;
                        if (trimmed.StartsWith("{"))
                        {
                            parsed = JsonSerializer.Deserialize<LoginModel>(body, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
                        }

                        if (parsed != null)
                        {
                            model = parsed;
                        }
                        else if (body.Contains("=") && body.Contains("&"))
                        {
                            // Fallback: parse URL-encoded-like body even if Content-Type was JSON
                            var query = QueryHelpers.ParseQuery(body.StartsWith("?") ? body : "?" + body);
                            if (query.TryGetValue("userName", out var u1)) model.UserName = u1.ToString();
                            if (string.IsNullOrWhiteSpace(model.UserName) && query.TryGetValue("username", out var u2)) model.UserName = u2.ToString();
                            if (string.IsNullOrWhiteSpace(model.UserName) && query.TryGetValue("email", out var u3)) model.UserName = u3.ToString();
                            if (query.TryGetValue("password", out var p)) model.Password = p.ToString();
                        }
                    }
                }
            }
            catch
            {
                return BadRequest(new { message = "Invalid login payload format." });
            }

            if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest(new { message = "Missing userName/email or password." });
            }

            return await LoginCore(model);
        }

        private async Task<IActionResult> LoginCore(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Console.WriteLine($"Login attempt for: '{model.UserName}'");

                var user = await _userService.FindUserByUserNameAsync(model.UserName);
                // Fallback: if "userName" actually contains an email, try email lookup
                if (user == null && !string.IsNullOrWhiteSpace(model.UserName) && model.UserName.Contains("@"))
                {
                    user = await _userService.FindUserByEmailAsync(model.UserName);
                }

                if (user == null)
                {
                    Console.WriteLine("Login failed: user not found");
                    return Unauthorized(new { message = "Invalid credentials" });
                }

                var passwordValid = await _userService.CheckPasswordAsync(user, model.Password);
                if (!passwordValid)
                {
                    Console.WriteLine("Login failed: invalid password");
                    return Unauthorized(new { message = "Invalid credentials" });
                }

                var token = await _tokenService.CreateToken(user);
                Console.WriteLine("Login succeeded");
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login error: {ex.Message}\n{ex.StackTrace}");
                return StatusCode(500, new { message = "Login failed due to a server error." });
            }
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
