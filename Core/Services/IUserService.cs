using System.Threading.Tasks;
using bedayzAPI.Core.Models;
using bedayzAPI.Core.Services.Communication;
using bedayzAPI.Domain.Services.Communication;

namespace bedayzAPI.Core.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(User user, params ERole[] userRoles);
        Task<User> FindByEmailAsync(string email);
        Task<CreateUserResponse> UpdateAsync(string email, User user);
    }
}