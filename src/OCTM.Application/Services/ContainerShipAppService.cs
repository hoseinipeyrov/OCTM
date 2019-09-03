using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using OCTM.Application.EventSourcedNormalizers.ContainerShip;
using OCTM.Application.Interfaces;
using OCTM.Application.ViewModels;
using OCTM.Domain.Commands;
using OCTM.Domain.Core.Bus;
using OCTM.Domain.Interfaces;
using OCTM.Infra.Data.Repository.EventSourcing;

namespace OCTM.Application.Services
{
    public class ContainerShipAppService : IContainerShipAppService
    {
        private readonly IMapper _mapper;
        private readonly IContainerShipRepository _containerShipRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ContainerShipAppService(IMapper mapper,
                                  IContainerShipRepository containerShipRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _containerShipRepository = containerShipRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<ContainerShipViewModel> GetAll()
        {
            return _containerShipRepository.GetAll().ProjectTo<ContainerShipViewModel>(_mapper.ConfigurationProvider);
        }

        public ContainerShipViewModel GetById(Guid id)
        {
            return _mapper.Map<ContainerShipViewModel>(_containerShipRepository.GetById(id));
        }

        public void Create(ContainerShipViewModel containerShipViewModel)
        {
            var createCommand = _mapper.Map<CreateNewContainerShipCommand>(containerShipViewModel);
            Bus.SendCommand(createCommand);
        }

        public void Update(ContainerShipViewModel containerShipViewModel)
        {
            var updateCommand = _mapper.Map<UpdateContainerShipCommand>(containerShipViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveContainerShipCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<ContainerShipHistoryData> GetAllHistory(Guid id)
        {
            return ContainerShipHistory.ToJavaScriptContainerShipHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
