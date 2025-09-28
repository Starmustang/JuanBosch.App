using JuanBosch.App.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace JuanBosch.App.Models.Persistence
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var roles = new[] { "Admin", "Doctor", "Patient" };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new ApplicationRole(role));
                }
            }

            if (!userManager.Users.Any())
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@juanbosch.com",
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, "Pa$$w0rd");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
