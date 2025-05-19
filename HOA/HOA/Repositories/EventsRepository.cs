using HOA.Data;
using HOA.Models;
using HOA.Repositories.Interfaces;

namespace HOA.Repositories
{
    public class EventsRepository : RepositoryBase<Event>, IEventsRepository
    {
        public EventsRepository(HOAContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
