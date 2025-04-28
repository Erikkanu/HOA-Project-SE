using HOA.Models;
using HOA.Repositories.Interfaces;

namespace HOA.Repositories
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly HOADbContext _context;
        private IResidentsRepository _residents;
        private IPaymentsRepository _payments;

        public RepositoryWrapper(HOADbContext context)
        {
            _context = context;
        }

        public IResidentsRepository ResidentsRepository
        {
            get
            {
                if (_residents == null)
                {
                    _residents = new ResidentsRepository(_context);
                }
                return _residents;
            }
        }

        public IPaymentsRepository PaymentsRepository
        {
            get
            {
                if (_payments == null)
                {
                    _payments = new PaymentsRepository(_context);
                }
                return _payments;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
