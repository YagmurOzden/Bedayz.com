using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bedayzAPI.Domain.Models;
using bedayzAPI.Domain.Repositories;
using bedayzAPI.Persistence.Contexts;

namespace bedayzAPI.Persistence.Repositories
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            return await _context.Images.Include(p => p.Product)
                                          .ToListAsync();
        }
        public async Task AddAsync(Image image)//Ekle
        {
            await _context.Images.AddAsync(image);
        }
        public async Task<Image> FindByIdAsync(int id)//Bul
        {
            return await _context.Images.FindAsync(id);
        }
        public void Update(Image image)//Güncelle
        {
            _context.Images.Update(image);
        }
        public void Remove(Image image)//Kaldır
        {
            _context.Images.Remove(image);
        }
    }
}
