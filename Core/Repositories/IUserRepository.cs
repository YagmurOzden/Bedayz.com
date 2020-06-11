using System.Threading.Tasks;
using bedayzAPI.Core.Models;

namespace bedayzAPI.Core.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user, ERole[] userRoles);
        Task<User> FindByEmailAsync(string email);
        void Update(User user);
    }
}