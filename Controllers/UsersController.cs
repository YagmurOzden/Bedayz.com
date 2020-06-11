using System.Threading.Tasks;
using AutoMapper;
using bedayzAPI.Controllers.Resources;
using bedayzAPI.Core.Models;
using bedayzAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;
using bedayzAPI.Resources;
using bedayzAPI.Domain.Models;
using bedayzAPI.Extensions;

namespace bedayzAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCredentialsResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<UserCredentialsResource, User>(userCredentials);

            var response = await _userService.CreateUserAsync(user, ERole.Common);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var userResource = _mapper.Map<User, UserResource>(response.User);
            return Ok(userResource);
        }
        [HttpGet("{email}")]
        public async Task<UserResource> GetUserInfos(string email)
        {
            var userinfo = await _userService.FindByEmailAsync(email);
            var resource = _mapper.Map<User, UserResource>(userinfo);
            resource.Password = null;
            resource.Roles = null;
            return resource;
        }
        [HttpPut("{email}")]
        public async Task<IActionResult> PutAsync(string email, [FromBody] UserCredentialsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var siparis = _mapper.Map<UserCredentialsResource, User>(resource);
            var result = await _userService.UpdateAsync(email, siparis);

            if (!result.Success)
                return BadRequest(result.Message);

            var siparisResource = _mapper.Map<User, UserResource>(result.User);
            return Ok(siparisResource);
        }
    }
}