using AutoMapper;
using Swiks.API.AutoMapper.Profiles;

namespace Swiks.API.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile<DomainToViewModel>();
                config.AddProfile<ViewModelToDomain>();
            });
        }
    }
}
