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
                Console.WriteLine("Starting user seeding process...");
                
                // Always ensure roles exist
                var requiredRoles = new[] { "Administrador", "usuario", "auxiliar" };
                foreach (var roleName in requiredRoles)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        var role = new ApplicationRole(roleName);
                        var roleResult = await roleManager.CreateAsync(role);
                        if (roleResult.Succeeded)
                        {
                            Console.WriteLine($"Created role: {roleName}");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to create role {roleName}: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Role already exists: {roleName}");
                    }
                }

                // Always ensure admin user exists
                var adminUser = await userManager.FindByNameAsync("admin");
                if (adminUser == null)
                {
                    Console.WriteLine("Admin user not found. Creating admin user...");
                    adminUser = new ApplicationUser
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
                        Console.WriteLine("Admin user created successfully");
                        
                        // Ensure admin has the Administrador role
                        if (!await userManager.IsInRoleAsync(adminUser, "Administrador"))
                        {
                            var roleResult = await userManager.AddToRoleAsync(adminUser, "Administrador");
                            if (roleResult.Succeeded)
                            {
                                Console.WriteLine("Admin user added to Administrador role");
                            }
                            else
                            {
                                Console.WriteLine($"Failed to add admin to role: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    Console.WriteLine("Admin user already exists");
                    
                    // Ensure existing admin has the Administrador role
                    if (!await userManager.IsInRoleAsync(adminUser, "Administrador"))
                    {
                        var roleResult = await userManager.AddToRoleAsync(adminUser, "Administrador");
                        if (roleResult.Succeeded)
                        {
                            Console.WriteLine("Added Administrador role to existing admin user");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to add role to existing admin: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                        }
                    }
                }
                
                Console.WriteLine("User seeding process completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during user seeding: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw; // Re-throw to be handled by the calling code
            }
        }
    }
}
