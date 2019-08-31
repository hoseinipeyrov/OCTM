using OCTM.Domain.Models;

namespace OCTM.Domain.Interfaces
{
    public interface IContainerShipRepository : IRepository<ContainerShip>
    {
        ContainerShip GetByName(string name);
    }
}