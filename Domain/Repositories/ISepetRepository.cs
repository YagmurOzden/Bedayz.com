using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Domain.Models;

namespace bedayzAPI.Domain.Repositories
{
    public interface ISepetRepository
    {
        Task<IEnumerable<Sepet>> ListAsync();
        Task AddAsync(Sepet sepet);
        Task<Sepet> FindByIdAsync(int id);
        void Update(Sepet sepet);
        void Remove(Sepet sepet);
        Task<IEnumerable<Sepet>> FindByEmailAsync(string email);
    }
}
