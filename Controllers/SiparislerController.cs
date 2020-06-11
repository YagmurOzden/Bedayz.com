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
using bedayzAPI.Domain.Models;
using bedayzAPI.Domain.Services;
using bedayzAPI.Extensions;
using bedayzAPI.Persistence.Contexts;
using bedayzAPI.Resources;
using bedayzAPI.Services;

namespace bedayzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparislerController : Controller
    {
        private readonly ISiparisService _siparisService;
        private readonly IMapper _mapper;

        public SiparislerController(ISiparisService siparisService, IMapper mapper)
        {
            _siparisService = siparisService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SiparisResource>> ListAsync()//GetAllSync ile aynı kodlar.
        {
            var sipariss = await _siparisService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Siparis>, IEnumerable<SiparisResource>>(sipariss);
            return resources;
        }
        //[Authorize]
        [HttpGet("{email}")]
        public async Task<IEnumerable<SiparisResource>> GetWithUserEmail(string email)
        {
            IEnumerable<SiparisResource> resource = null;
            //var userEmail = User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            //if (userEmail == email)
            //{
            var userinfo = await _siparisService.FindByEmailAsync(email);
            resource = _mapper.Map<IEnumerable<Siparis>, IEnumerable<SiparisResource>>(userinfo);
            return resource;
            //}
            //return resource;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSiparisResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var siparis = _mapper.Map<SaveSiparisResource, Siparis>(resource);
            var result = await _siparisService.SaveAsync(siparis);

            if (!result.Success)
                return BadRequest(result.Message);

            var siparisResource = _mapper.Map<Siparis, SiparisResource>(result.Siparis);
            return Ok(siparisResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSiparisResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var siparis = _mapper.Map<SaveSiparisResource, Siparis>(resource);
            var result = await _siparisService.UpdateAsync(id, siparis);

            if (!result.Success)
                return BadRequest(result.Message);

            var siparisResource = _mapper.Map<Siparis, SaveSiparisResource>(result.Siparis);
            return Ok(siparisResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)//parametrede verilmiş olan id numarasına sahip veriyi siler.
        {
            var result = await _siparisService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var siparisResource = _mapper.Map<Siparis, SiparisResource>(result.Siparis);
            return Ok(siparisResource);
        }
    }
}