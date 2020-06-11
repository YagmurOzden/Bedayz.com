using System.Threading.Tasks;
using bedayzAPI.Core.Models;
using bedayzAPI.Core.Repositories;
using bedayzAPI.Core.Security.Hashing;
using bedayzAPI.Core.Services;
using bedayzAPI.Core.Services.Communication;
using bedayzAPI.Domain.Repositories;
using System;

namespace bedayzAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> CreateUserAsync(User user, params ERole[] userRoles)
        {
            var existingUser = await _userRepository.FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return new CreateUserResponse(false, "Email already in use.", null);
            }

            user.Password = _passwordHasher.HashPassword(user.Password);

            await _userRepository.AddAsync(user, userRoles);
            await _unitOfWork.CompleteAsync();

            return new CreateUserResponse(true, null, user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }

        public async Task<CreateUserResponse> UpdateAsync(string email, User siparis)
        {

            var existingUser = await _userRepository.FindByEmailAsync(email);

            if (existingUser == null)
                return new CreateUserResponse("Siparis not found.");

            existingUser.Email = siparis.Email;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new CreateUserResponse(existingUser);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CreateUserResponse($"An error occurred when updating the siparis: {ex.Message}");
            }
        }
    }
}