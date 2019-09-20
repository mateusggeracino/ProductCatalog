using AutoMapper;
using Swiks.API.ViewModels.Response;
using Swiks.Domain.Entities;

namespace Swiks.API.AutoMapper.Profiles
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Product, ProductResponseViewModel>();
        }
    }
}
