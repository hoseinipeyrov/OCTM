using System;
using OCTM.Domain.Core.Commands;

namespace OCTM.Domain.Commands
{
    public abstract class ContainerShipCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public int Capacity{ get; protected set; }

        public string Color{ get; protected set; }
    }
}