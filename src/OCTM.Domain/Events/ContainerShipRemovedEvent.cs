using System;
using OCTM.Domain.Core.Events;

namespace OCTM.Domain.Events
{
    public class ContainerShipRemovedEvent : Event
    {
        public ContainerShipRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}