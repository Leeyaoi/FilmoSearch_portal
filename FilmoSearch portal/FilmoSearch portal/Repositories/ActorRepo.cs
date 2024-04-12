using FilmoSearch_portal.Data;
using FilmoSearch_portal.Interfaces;
using FilmoSearch_portal.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmoSearch_portal.Repositories
{
    public class ActorRepo : IActor
    {
        private readonly PortalContext _context;

        public ActorRepo(PortalContext context)
        {
            _context = context;
        }

        public void Delete(Actor actor)
        {
            _context.Actors.Remove(actor);
        }

        public List<Actor> GetAll()
        {
            return _context.Actors.ToList();
        }

        public Actor GetById(int id)
        {
            return _context.Actors
                .Include(a => a.Roles)
                .ThenInclude(r => r.Film)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Actor actor)
        {
            _context.Actors.Add(actor);
        }

        public void Update(Actor actor)
        {
            _context.Actors.Update(actor);
        }
    }
}
