using bedayzAPI.Core.Models;

namespace bedayzAPI.Core.Services.Communication
{
    public class CreateUserResponse : BaseResponse
    {
        public User User { get; private set; }

        public CreateUserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }
        public CreateUserResponse(User siparis) : this(true, string.Empty, siparis)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CreateUserResponse(string message) : this(false, message, null)
        { }
    }
}