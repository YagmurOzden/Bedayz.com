using AutoMapper;
using bedayzAPI.Controllers.Resources;
using bedayzAPI.Core.Models;
using bedayzAPI.Domain.Models;
using bedayzAPI.Resources;

namespace bedayzAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveImageResource, Image>();
            CreateMap<SaveSiparisResource, Siparis>();
            CreateMap<SaveSepetResource, Sepet>();
            CreateMap<UserCredentialsResource, User>();
        }
    }
}