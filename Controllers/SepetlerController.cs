using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using bedayzAPI.Controllers.Resources;
using bedayzAPI.Core.Models;
using bedayzAPI.Core.Services;
using bedayzAPI.Domain.Models;
using bedayzAPI.Domain.Services;
using bedayzAPI.Extensions;
using bedayzAPI.Persistence.Contexts;
using bedayzAPI.Resources;

namespace bedayzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SepetlerController : Controller
    {
        private readonly ISepetService _sepetService;
        private readonly IMapper _mapper;

        public SepetlerController(ISepetService sepetService, IMapper mapper)
        {
            _sepetService = sepetService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SepetResource>> ListAsync()//GetAllSync ile aynı kodlar.
        {
            var sepets = await _sepetService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Sepet>, IEnumerable<SepetResource>>(sepets);
            return resources;
        }

        //[Authorize(Policy = "SameEmail")]
        [HttpGet("{email}")]
        public async Task<IEnumerable<SepetResource>> GetWithUserEmail(string email)
        {
            IEnumerable<SepetResource> resource = null;
            //var userEmail = User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            //if (userEmail== email)
            //{
            var userinfo = await _sepetService.FindByEmailAsync(email);
            resource = _mapper.Map<IEnumerable<Sepet>, IEnumerable<SepetResource>>(userinfo);
            //return resource;
            // }
            return resource;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSepetResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var sepet = _mapper.Map<SaveSepetResource, Sepet>(resource);
            var result = await _sepetService.SaveAsync(sepet);

            if (!result.Success)
                return BadRequest(result.Message);

            var sepetResource = _mapper.Map<Sepet, SepetResource>(result.Sepet);
            return Ok(sepetResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSepetResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var sepet = _mapper.Map<SaveSepetResource, Sepet>(resource);
            var result = await _sepetService.UpdateAsync(id, sepet);

            if (!result.Success)
                return BadRequest(result.Message);

            var sepetResource = _mapper.Map<Sepet, SaveSepetResource>(result.Sepet);
            return Ok(sepetResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)//parametrede verilmiş olan id numarasına sahip veriyi siler.
        {
            var result = await _sepetService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var sepetResource = _mapper.Map<Sepet, SepetResource>(result.Sepet);
            return Ok(sepetResource);
        }
    }
}