using AutoMapper;
using Swiks.API.ViewModels.Request;
using Swiks.Domain.Entities;

namespace Swiks.API.AutoMapper.Profiles
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<ProductRequestViewModel, Product>();
        }
    }
}
