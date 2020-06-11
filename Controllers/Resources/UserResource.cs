using System.Collections.Generic;

namespace bedayzAPI.Controllers.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}