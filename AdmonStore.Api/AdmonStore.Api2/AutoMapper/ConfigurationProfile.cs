using AutoMapper;

namespace AdmonStore.Api2.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<NewProduct, Product>().ReverseMap();
            CreateMap<ProductEntity, Product>().ReverseMap();
        }
    }
}
