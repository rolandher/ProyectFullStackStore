using AdmonStore.Entities2.Commands;
using AdmonStore.Entities2.Entities;
using AutoMapper;

namespace AdmonStore.Api2.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<NewStore, Store>().ReverseMap();
            CreateMap<NewLocation, Location>().ReverseMap();
        }
    }
}
