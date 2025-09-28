using JuanBosch.App.Models.Users;
using System.Threading.Tasks;

namespace JuanBosch.App.Services.Interface
{
    public interface ITokenService
    {
        Task<string> CreateToken(ApplicationUser user);
    }
}
