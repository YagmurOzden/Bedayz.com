using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Domain.Models;
using bedayzAPI.Domain.Services.Communication;

namespace bedayzAPI.Domain.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> ListAsync();
        Task<ImageResponse> SaveAsync(Image image);
        Task<ImageResponse> UpdateAsync(int id, Image image);
        Task<ImageResponse> DeleteAsync(int id);
    }
}
