using FilmoSearch_portal.Data;
using FilmoSearch_portal.Interfaces;
using FilmoSearch_portal.Models;

namespace FilmoSearch_portal.Repositories
{
    public class PortalRepo : IPortal
    {
        private readonly PortalContext _context;

        private FilmRepo? _filmRepo;

        private ActorRepo? _actorRepo;

        public PortalRepo(PortalContext context)
        {
            _context = context;
        }

        public IActor Actor
        {
            get
            {
                return _actorRepo = _actorRepo ?? new ActorRepo(_context);
            }
        }

        public IFilm Film
        {
            get
            {
                return _filmRepo = _filmRepo ?? new FilmRepo(_context);
            }
        }
        public string Title => throw new NotImplementedException();

        

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
