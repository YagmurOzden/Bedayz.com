using System.ComponentModel.DataAnnotations;

namespace bedayzAPI.Controllers.Resources
{
    public class RevokeTokenResource
    {
        [Required]
        public string Token { get; set; }
    }
}