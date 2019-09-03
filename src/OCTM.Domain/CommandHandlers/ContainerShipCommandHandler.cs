using System;
using System.Threading;
using System.Threading.Tasks;
using OCTM.Domain.Commands;
using OCTM.Domain.Core.Bus;
using OCTM.Domain.Core.Notifications;
using OCTM.Domain.Events;
using OCTM.Domain.Interfaces;
using OCTM.Domain.Models;
using MediatR;

namespace OCTM.Domain.CommandHandlers
{
    public class ContainerShipCommandHandler : CommandHandler,
        IRequestHandler<CreateNewContainerShipCommand, bool>,
        IRequestHandler<UpdateContainerShipCommand, bool>,
        IRequestHandler<RemoveContainerShipCommand, bool>
    {
        private readonly IContainerShipRepository _containerShipRepository;
        private readonly IMediatorHandler Bus;

        public ContainerShipCommandHandler(IContainerShipRepository containerShipRepository, 
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _containerShipRepository = containerShipRepository;
            Bus = bus;
        }

        public Task<bool> Handle(CreateNewContainerShipCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var containerShip = new ContainerShip(Guid.NewGuid(), message.Name, message.Capacity, message.Color);

            if (_containerShipRepository.GetByName(containerShip.Name) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The ContainerShip name has already been taken."));
                return Task.FromResult(false);
            }

            _containerShipRepository.Add(containerShip);

            if (Commit())
            {
                Bus.RaiseEvent(new ContainerShipRegisteredEvent(containerShip.Id, containerShip.Name, containerShip.Capacity, containerShip.Color));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateContainerShipCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var containerShip = new ContainerShip(message.Id, message.Name, message.Capacity, message.Color);
            var existingContainerShip = _containerShipRepository.GetByName(containerShip.Name);

            if (existingContainerShip != null && existingContainerShip.Id != containerShip.Id)
            {
                if (!existingContainerShip.Equals(containerShip))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The ContainerShip name has already been taken."));
                    return Task.FromResult(false);
                }
            }

            _containerShipRepository.Update(containerShip);

            if (Commit())
            {
                Bus.RaiseEvent(new ContainerShipUpdatedEvent(containerShip.Id, containerShip.Name, containerShip.Capacity, containerShip.Color));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveContainerShipCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _containerShipRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ContainerShipRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _containerShipRepository.Dispose();
        }
    }
}