using JuanBosch.App.Models.Users;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JuanBosch.App.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _config = config;
            var key = _config["Jwt:Key"]
                      ?? Environment.GetEnvironmentVariable("Jwt__Key")
                      ?? Environment.GetEnvironmentVariable("JWT_KEY");

            if (string.IsNullOrWhiteSpace(key))
            {
                Console.WriteLine("WARNING: JWT signing key not configured. Set 'Jwt:Key' or env 'Jwt__Key'/'JWT_KEY'. Using placeholder key.");
                key = "__MISSING_JWT_KEY__"; // placeholder to avoid null exceptions
            }

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            _userManager = userManager;
        }

        public async Task<string> CreateToken(ApplicationUser user)
        {
            Console.WriteLine($"=== TOKEN CREATION START for user: {user.UserName} ===");
            
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName!),
                };
                Console.WriteLine($"Basic claims added for user: {user.UserName}");

                // Get user roles with error handling
                IList<string> roles;
                try
                {
                    roles = await _userManager.GetRolesAsync(user);
                    Console.WriteLine($"Retrieved {roles.Count} roles for user {user.UserName}: [{string.Join(", ", roles)}]");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to get roles for user {user.UserName}: {ex.Message}");
                    roles = new List<string>(); // Continue with empty roles to prevent login failure
                }

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                Console.WriteLine($"Total claims: {claims.Count}");

                var issuer = _config["Jwt:Issuer"]
                             ?? Environment.GetEnvironmentVariable("Jwt__Issuer")
                             ?? Environment.GetEnvironmentVariable("JWT_ISSUER")
                             ?? "JuanBoschApp";
                var audience = _config["Jwt:Audience"]
                               ?? Environment.GetEnvironmentVariable("Jwt__Audience")
                               ?? Environment.GetEnvironmentVariable("JWT_AUDIENCE")
                               ?? "JuanBoschApp";
                Console.WriteLine($"Using Issuer: {issuer}, Audience: {audience}");

                var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = creds,
                    Issuer = issuer,
                    Audience = audience
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                Console.WriteLine("Creating JWT token...");

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                
                Console.WriteLine($"Token created successfully. Length: {tokenString.Length}");
                Console.WriteLine($"=== TOKEN CREATION END ===");
                
                return tokenString;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in CreateToken: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }
    }
}
