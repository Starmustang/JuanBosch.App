using JuanBosch.App.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JuanBosch.App.Services.Interface
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser?> FindUserByEmailAsync(string email);
        Task<ApplicationUser?> FindUserByUserNameAsync(string username);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
        Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string roleName);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    }
}
