using OCTM.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCTM.Domain.Models
{
    public class ContainerShip : Entity
    {
        // Empty constructor for EF
        protected ContainerShip() { }

        public ContainerShip(Guid id, string name, int capacity, string color)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
            Color = color;
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public string Color { get; private set; }

    }
}
