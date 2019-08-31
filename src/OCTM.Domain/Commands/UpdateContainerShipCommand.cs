using System;
using OCTM.Domain.Validations;

namespace OCTM.Domain.Commands
{
    public class UpdateContainerShipCommand : ContainerShipCommand
    {
        public UpdateContainerShipCommand(Guid id, string name, int capacity, string color)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
            Color = color;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateContainerShipCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}