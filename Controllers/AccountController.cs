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
using Microsoft.Extensions.Hosting;

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
            Console.WriteLine($"=== LOGIN REQUEST START ===");
            Console.WriteLine($"Content-Type: {Request.ContentType}");
            Console.WriteLine($"Method: {Request.Method}");
            Console.WriteLine($"Has Form Content: {Request.HasFormContentType}");
            
            var model = new LoginModel();

            try
            {
                if (Request.HasFormContentType)
                {
                    Console.WriteLine("Processing as form data...");
                    var form = await Request.ReadFormAsync();
                    model.UserName = form["userName"].ToString() ?? form["username"].ToString();
                    if (string.IsNullOrWhiteSpace(model.UserName) && form.ContainsKey("email"))
                    {
                        model.UserName = form["email"].ToString();
                    }
                    model.Password = form["password"].ToString();
                    Console.WriteLine($"Form parsed - UserName: '{model.UserName}', Password length: {model.Password?.Length ?? 0}");
                }
                else
                {
                    Console.WriteLine("Processing as body content...");
                    using var reader = new StreamReader(Request.Body);
                    var body = await reader.ReadToEndAsync();
                    Console.WriteLine($"Raw body: {body}");
                    
                    if (!string.IsNullOrWhiteSpace(body))
                    {
                        var trimmed = body.TrimStart();
                        var parsed = (LoginModel?)null;
                        if (trimmed.StartsWith("{"))
                        {
                            Console.WriteLine("Parsing as JSON...");
                            parsed = JsonSerializer.Deserialize<LoginModel>(body, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
                        }

                        if (parsed != null)
                        {
                            model = parsed;
                            Console.WriteLine($"JSON parsed - UserName: '{model.UserName}', Password length: {model.Password?.Length ?? 0}");
                        }
                        else if (body.Contains("=") && body.Contains("&"))
                        {
                            Console.WriteLine("Parsing as URL-encoded fallback...");
                            // Fallback: parse URL-encoded-like body even if Content-Type was JSON
                            var query = QueryHelpers.ParseQuery(body.StartsWith("?") ? body : "?" + body);
                            if (query.TryGetValue("userName", out var u1)) model.UserName = u1.ToString();
                            if (string.IsNullOrWhiteSpace(model.UserName) && query.TryGetValue("username", out var u2)) model.UserName = u2.ToString();
                            if (string.IsNullOrWhiteSpace(model.UserName) && query.TryGetValue("email", out var u3)) model.UserName = u3.ToString();
                            if (query.TryGetValue("password", out var p)) model.Password = p.ToString();
                            Console.WriteLine($"URL-encoded parsed - UserName: '{model.UserName}', Password length: {model.Password?.Length ?? 0}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var traceId = HttpContext.TraceIdentifier;
                Console.WriteLine($"Error parsing request [TraceId={traceId}]: {ex.Message}\n{ex.StackTrace}");
                var expose = Environment.GetEnvironmentVariable("EXPOSE_DETAILED_ERRORS");
                var showDetails = string.Equals(expose, "true", StringComparison.OrdinalIgnoreCase)
                                  || string.Equals(expose, "1", StringComparison.OrdinalIgnoreCase)
                                  || string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Development", StringComparison.OrdinalIgnoreCase);
                if (showDetails)
                {
                    return BadRequest(new { message = "Invalid login payload format.", traceId, error = ex.Message, stack = ex.StackTrace });
                }
                return BadRequest(new { message = "Invalid login payload format.", traceId });
            }

            if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Password))
            {
                Console.WriteLine($"Missing credentials - UserName: '{model.UserName}', Password: {(string.IsNullOrWhiteSpace(model.Password) ? "EMPTY" : "PROVIDED")}");
                return BadRequest(new { message = "Missing userName/email or password." });
            }

            Console.WriteLine($"Proceeding to LoginCore with UserName: '{model.UserName}'");
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
                var traceId = HttpContext.TraceIdentifier;
                Console.WriteLine($"Login error [TraceId={traceId}]: {ex.Message}\n{ex.StackTrace}");
                var expose = Environment.GetEnvironmentVariable("EXPOSE_DETAILED_ERRORS");
                var showDetails = string.Equals(expose, "true", StringComparison.OrdinalIgnoreCase)
                                  || string.Equals(expose, "1", StringComparison.OrdinalIgnoreCase)
                                  || string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Development", StringComparison.OrdinalIgnoreCase);
                if (showDetails)
                {
                    return StatusCode(500, new
                    {
                        message = "Login failed due to a server error.",
                        traceId,
                        error = ex.Message,
                        stack = ex.StackTrace,
                        inner = ex.InnerException?.Message
                    });
                }
                return StatusCode(500, new { message = "Login failed due to a server error.", traceId });
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
