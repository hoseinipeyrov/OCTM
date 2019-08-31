using OCTM.Domain.Commands;

namespace OCTM.Domain.Validations
{
    public class RegisterNewContainerShipCommandValidation : ContainerShipValidation<RegisterNewContainerShipCommand>
    {
        public RegisterNewContainerShipCommandValidation()
        {
            ValidateName();
            ValidateCapacity();
            ValidateColor();
        }
    }
}