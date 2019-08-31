using System.Linq;
using OCTM.Domain.Interfaces;
using OCTM.Domain.Models;
using OCTM.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace OCTM.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OCTMContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
