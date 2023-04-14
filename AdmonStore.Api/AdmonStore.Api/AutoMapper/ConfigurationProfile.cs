using AdmonStore.Infrastructure.Entities;
using AdmonStoreDomain.Entities.Commands;
using AdmonStoreDomain.Entities.Entities;
using AutoMapper;

namespace AdmonStore.Api.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<NewUser, User>().ReverseMap();
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<NewUser, UserEntity>().ReverseMap();
        }
            
    }
}
