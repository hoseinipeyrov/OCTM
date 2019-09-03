using System;
using OCTM.Domain.Validations;

namespace OCTM.Domain.Commands
{
    public class CreateNewContainerShipCommand : ContainerShipCommand
    {
        public CreateNewContainerShipCommand(string name, int capacity, string color)
        {
            Name = name;
            Capacity = capacity;
            Color = color;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewContainerShipCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}