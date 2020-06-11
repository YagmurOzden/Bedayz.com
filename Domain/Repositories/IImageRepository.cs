using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Domain.Models;

namespace bedayzAPI.Domain.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> ListAsync();
        Task AddAsync(Image image);
        Task<Image> FindByIdAsync(int id);
        void Update(Image image);
        void Remove(Image image);
    }
}
