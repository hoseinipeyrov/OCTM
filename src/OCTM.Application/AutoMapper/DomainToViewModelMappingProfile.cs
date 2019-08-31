using AutoMapper;
using OCTM.Application.ViewModels;
using OCTM.Domain.Models;

namespace OCTM.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
