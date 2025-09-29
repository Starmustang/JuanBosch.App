using JuanBosch.App.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JuanBosch.App.Services.Interface
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRoleAsync(string name, string? description = null);
        Task<IdentityResult> UpdateRoleAsync(string roleId, string newName, string? description);
        Task<IdentityResult> DeleteRoleAsync(string roleId);
        Task<IEnumerable<ApplicationRole>> GetRolesAsync();

        Task<IdentityResult> AddUserToRoleAsync(string userId, string roleName);
        Task<IdentityResult> RemoveUserFromRoleAsync(string userId, string roleName);
        Task<IList<string>> GetUserRolesAsync(string userId);
    }
}
