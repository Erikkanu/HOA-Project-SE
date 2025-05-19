using HOA.Data;
using HOA.Models;
using HOA.Repositories.Interfaces;

namespace HOA.Repositories
{
    public class PaymentsRepository : RepositoryBase<Payment>, IPaymentsRepository
    {
        public PaymentsRepository(HOAContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
