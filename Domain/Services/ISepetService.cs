using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Domain.Models;
using bedayzAPI.Domain.Services;
using bedayzAPI.Domain.Repositories;
using bedayzAPI.Persistence.Repositories;
using bedayzAPI.Domain.Services.Communication;

namespace bedayzAPI.Domain.Services
{
    public interface ISepetService
    {
        Task<IEnumerable<Sepet>> ListAsync();
        Task<SepetResponse> SaveAsync(Sepet sepet);
        Task<SepetResponse> UpdateAsync(int id, Sepet sepet);
        Task<SepetResponse> DeleteAsync(int id);
        Task<IEnumerable<Sepet>> FindByEmailAsync(string email);
    }
}

