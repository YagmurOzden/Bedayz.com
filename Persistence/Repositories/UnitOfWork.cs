using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Domain.Repositories;
using bedayzAPI.Persistence.Contexts;

namespace bedayzAPI.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
