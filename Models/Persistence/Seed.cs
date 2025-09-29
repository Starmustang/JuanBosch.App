using JuanBosch.App.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JuanBosch.App.Models.Persistence
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            try
            {
                // Check if roles exist, if not create them
                var existingRoles = roleManager.Roles.ToList();
                if (!existingRoles.Any())
                {
                    var roles = new[] { "Administrador", "usuario", "auxiliar" };
                    foreach (var role in roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(new ApplicationRole(role));
                        }
                    }
                }

                // Check if users exist, if not create admin user
                var existingUsers = userManager.Users.ToList();
                if (!existingUsers.Any())
                {
                    var adminUser = new ApplicationUser
                    {
                        UserName = "admin",
                        Email = "admin@juanbosch.com",
                        FirstName = "Admin",
                        LastName = "User",
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(adminUser, "123456789wW#");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, "Administrador");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error but don't crash the application
                Console.WriteLine($"Error during user seeding: {ex.Message}");
                throw; // Re-throw to be handled by the calling code
            }
        }
    }
}
