using System;
using OCTM.Domain.Core.Events;

namespace OCTM.Domain.Events
{
    public class ContainerShipUpdatedEvent : Event
    {
        public ContainerShipUpdatedEvent(Guid id, string name, int capacity, string color)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
            Color = color;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public int Capacity{ get; private set; }

        public string Color{ get; private set; }
    }
}