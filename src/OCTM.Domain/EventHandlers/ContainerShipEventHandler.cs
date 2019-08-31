using System.Threading;
using System.Threading.Tasks;
using OCTM.Domain.Events;
using MediatR;

namespace OCTM.Domain.EventHandlers
{
    public class ContainerShipEventHandler :
        INotificationHandler<ContainerShipRegisteredEvent>,
        INotificationHandler<ContainerShipUpdatedEvent>,
        INotificationHandler<ContainerShipRemovedEvent>
    {
        public Task Handle(ContainerShipUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ContainerShipRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ContainerShipRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}