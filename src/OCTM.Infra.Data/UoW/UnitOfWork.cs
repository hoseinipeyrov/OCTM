using OCTM.Domain.Interfaces;
using OCTM.Infra.Data.Context;

namespace OCTM.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OCTMContext _context;

        public UnitOfWork(OCTMContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
