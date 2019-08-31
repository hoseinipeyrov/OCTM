using AutoMapper;
using OCTM.Application.ViewModels;
using OCTM.Domain.Commands;

namespace OCTM.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));

            CreateMap<ContainerShipViewModel, RegisterNewContainerShipCommand>()
                .ConstructUsing(c => new RegisterNewContainerShipCommand(c.Name, c.Capacity, c.Color));
            CreateMap<ContainerShipViewModel, UpdateContainerShipCommand>()
                .ConstructUsing(c => new UpdateContainerShipCommand(c.Id, c.Name, c.Capacity, c.Color));
        }
    }
}
