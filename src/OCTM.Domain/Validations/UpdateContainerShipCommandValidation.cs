using OCTM.Domain.Commands;

namespace OCTM.Domain.Validations
{
    public class UpdateContainerShipCommandValidation : ContainerShipValidation<UpdateContainerShipCommand>
    {
        public UpdateContainerShipCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateColor();
            ValidateCapacity();
        }
    }
}