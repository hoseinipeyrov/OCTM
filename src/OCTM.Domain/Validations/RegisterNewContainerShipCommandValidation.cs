using OCTM.Domain.Commands;

namespace OCTM.Domain.Validations
{
    public class RegisterNewContainerShipCommandValidation : ContainerShipValidation<CreateNewContainerShipCommand>
    {
        public RegisterNewContainerShipCommandValidation()
        {
            ValidateName();
            ValidateCapacity();
            ValidateColor();
        }
    }
}