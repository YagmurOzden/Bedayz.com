using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using bedayzAPI.Domain.Models;
using bedayzAPI.Domain.Services;
using bedayzAPI.Extensions;
using bedayzAPI.Resources;

namespace bedayzAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ImageResource>> ListAsync()//GetAllSync ile aynı kodlar.
        {
            var images = await _imageService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Image>, IEnumerable<ImageResource>>(images);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveImageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var image = _mapper.Map<SaveImageResource, Image>(resource);
            var result = await _imageService.SaveAsync(image);

            if (!result.Success)
                return BadRequest(result.Message);

            var imageResource = _mapper.Map<Image, ImageResource>(result.Image);
            return Ok(imageResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveImageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var image = _mapper.Map<SaveImageResource, Image>(resource);
            var result = await _imageService.UpdateAsync(id, image);

            if (!result.Success)
                return BadRequest(result.Message);

            var imageResource = _mapper.Map<Image, SaveImageResource>(result.Image);
            return Ok(imageResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)//parametrede verilmiş olan id numarasına sahip veriyi siler.
        {
            var result = await _imageService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var imageResource = _mapper.Map<Image, ImageResource>(result.Image);
            return Ok(imageResource);
        }
    }
}