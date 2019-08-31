using System;
using OCTM.Domain.Validations;

namespace OCTM.Domain.Commands
{
    public class RemoveContainerShipCommand : ContainerShipCommand
    {
        public RemoveContainerShipCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveContainerShipCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}