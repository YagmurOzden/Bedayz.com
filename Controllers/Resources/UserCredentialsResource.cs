using System.ComponentModel.DataAnnotations;

namespace bedayzAPI.Controllers.Resources
{
    public class UserCredentialsResource
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}