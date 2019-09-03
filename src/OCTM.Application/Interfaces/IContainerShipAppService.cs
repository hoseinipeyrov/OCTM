using System;
using System.Collections.Generic;
using OCTM.Application.EventSourcedNormalizers.ContainerShip;
using OCTM.Application.ViewModels;

namespace OCTM.Application.Interfaces
{
    public interface IContainerShipAppService : IDisposable
    {
        void Create(ContainerShipViewModel containerShipViewModel);
        IEnumerable<ContainerShipViewModel> GetAll();
        ContainerShipViewModel GetById(Guid id);
        void Update(ContainerShipViewModel containerShipViewModel);
        void Remove(Guid id);
        IList<ContainerShipHistoryData> GetAllHistory(Guid id);
    }
}
