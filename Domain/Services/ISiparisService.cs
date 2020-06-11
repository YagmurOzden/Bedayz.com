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
    public interface ISiparisService
    {
        Task<IEnumerable<Siparis>> ListAsync();
        Task<SiparisResponse> SaveAsync(Siparis siparis);
        Task<SiparisResponse> UpdateAsync(int id, Siparis siparis);
        Task<SiparisResponse> DeleteAsync(int id);
        Task<IEnumerable<Siparis>> FindByEmailAsync(string email);
    }
}

