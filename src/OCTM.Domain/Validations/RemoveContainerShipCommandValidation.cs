using OCTM.Domain.Commands;

namespace OCTM.Domain.Validations
{
    public class RemoveContainerShipCommandValidation : ContainerShipValidation<RemoveContainerShipCommand>
    {
        public RemoveContainerShipCommandValidation()
        {
            ValidateId();
        }
    }
}