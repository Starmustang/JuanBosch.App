using JuanBosch.App.Models.Users;
using JuanBosch.App.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanBosch.App.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateRoleAsync(string name, string? description = null)
        {
            var existing = await _roleManager.FindByNameAsync(name);
            if (existing != null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "RoleExists", Description = $"Role '{name}' already exists." });
            }

            var role = new ApplicationRole(name)
            {
                Description = description,
                IsActive = true
            };

            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> UpdateRoleAsync(string roleId, string newName, string? description)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "NotFound", Description = "Role not found." });
            }

            // if renaming, ensure no conflict
            if (!string.IsNullOrWhiteSpace(newName) && !string.Equals(role.Name, newName, System.StringComparison.OrdinalIgnoreCase))
            {
                var conflict = await _roleManager.FindByNameAsync(newName);
                if (conflict != null && conflict.Id != role.Id)
                {
                    return IdentityResult.Failed(new IdentityError { Code = "RoleExists", Description = $"Role '{newName}' already exists." });
                }
                role.Name = newName;
                role.NormalizedName = _roleManager.NormalizeKey(newName);
            }

            role.Description = description;

            return await _roleManager.UpdateAsync(role);
        }

        public async Task<IdentityResult> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "NotFound", Description = "Role not found." });
            }

            return await _roleManager.DeleteAsync(role);
        }

        public async Task<IEnumerable<ApplicationRole>> GetRolesAsync()
        {
            return await _roleManager.Roles.OrderBy(r => r.Name!).ToListAsync();
        }

        public async Task<IdentityResult> AddUserToRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "UserNotFound", Description = "User not found." });
            }

            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "RoleNotFound", Description = "Role not found." });
            }

            if (await _userManager.IsInRoleAsync(user, roleName))
            {
                return IdentityResult.Success; // already in role
            }

            return await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> RemoveUserFromRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "UserNotFound", Description = "User not found." });
            }

            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                return IdentityResult.Success; // nothing to remove
            }

            return await _userManager.RemoveFromRoleAsync(user, roleName);
        }

        public async Task<IList<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new List<string>();
            }

            return await _userManager.GetRolesAsync(user);
        }
    }
}
