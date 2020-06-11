using AutoMapper;
using System.Linq;
using bedayzAPI.Controllers.Resources;
using bedayzAPI.Core.Models;
using bedayzAPI.Core.Security.Tokens;
using bedayzAPI.Domain.Models;
using bedayzAPI.Extensions;
using bedayzAPI.Resources;

namespace bedayzAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(src => src.Marka,
                           opt => opt.MapFrom(src => src.Marka.ToDescriptionString())).ForMember(src => src.Tag,
                           opt => opt.MapFrom(src => src.Tag.ToDescriptionString()));
            CreateMap<Image, ImageResource>();
            CreateMap<Sepet, SepetResource>();
            CreateMap<Siparis, SiparisResource>();
            CreateMap<User, UserResource>()
                 .ForMember(u => u.Roles, opt => opt.MapFrom(u => u.UserRoles.Select(ur => ur.Role.Name)));

            CreateMap<AccessToken, AccessTokenResource>()
                .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
                .ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
                .ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration));
        }
    }
}
