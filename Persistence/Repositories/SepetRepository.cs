using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Domain.Models;
using bedayzAPI.Domain.Repositories;
using bedayzAPI.Persistence.Contexts;

namespace bedayzAPI.Persistence.Repositories
{
    public class SepetRepository : BaseRepository, ISepetRepository
    {

        public SepetRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Sepet>> ListAsync()
        {
            //return await _context.Sepet.ToListAsync();
            var List = await _context.Sepet.Include(p => p.Product).ThenInclude(p => p.Category).Include(p => p.User)
                                        .ToListAsync();
            foreach (var item in List)
            {
                item.User.Password = null;
            }
            return List;
        }
        public async Task AddAsync(Sepet sepet)
        {
            await _context.Sepet.AddAsync(sepet);
        }
        public async Task<Sepet> FindByIdAsync(int id)
        {
            return await _context.Sepet.FindAsync(id);
        }
        public async Task<IEnumerable<Sepet>> FindByEmailAsync(string Email)
        {
            var List = await _context.Sepet.Where(p => p.User.Email == Email).Include(p => p.Product).ThenInclude(p => p.Category).Include(p => p.User)
                                        .ToListAsync();
            foreach (var item in List)
            {
                item.User.Password = null;
            }
            return List;
        }
        public void Update(Sepet sepet)
        {
            _context.Sepet.Update(sepet);
        }
        public void Remove(Sepet sepet)
        {
            _context.Sepet.Remove(sepet);
        }
    }
}