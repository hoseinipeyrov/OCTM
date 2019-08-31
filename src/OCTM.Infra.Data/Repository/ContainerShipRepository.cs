using System.Linq;
using OCTM.Domain.Interfaces;
using OCTM.Domain.Models;
using OCTM.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace OCTM.Infra.Data.Repository
{
    public class ContainerShipRepository : Repository<ContainerShip>, IContainerShipRepository
    {
        public ContainerShipRepository(OCTMContext context)
            : base(context)
        {

        }

        public ContainerShip GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }
    }
}
