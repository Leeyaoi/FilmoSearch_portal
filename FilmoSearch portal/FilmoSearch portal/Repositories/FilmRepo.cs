using FilmoSearch_portal.Data;
using FilmoSearch_portal.Interfaces;
using FilmoSearch_portal.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FilmoSearch_portal.Repositories
{
    public class FilmRepo : IFilm
    {
        private readonly PortalContext _context;
        private ReviewRepo _reviewRepo;

        public FilmRepo(PortalContext context)
        {
            _context = context;
        }

        public IReview Reviews
        {
            get
            {
                return _reviewRepo = _reviewRepo ?? new ReviewRepo(_context);
            }
        }

        public void Delete(Film film)
        {
            _context.Films.Remove(film);
        }

        public List<Film> GetAll()
        {
            return _context.Films.ToList();
        }

        public Film GetById(int id)
        {
            return _context.Films
                .Include(f => f.Reviews)
                .Include(f => f.Roles)
                .ThenInclude(r => r.Actor)
                .FirstOrDefault(x => x.Id == id)!;
        }

        public void Insert(Film film)
        {
            _context.Films.Add(film);
        }

        public void Update(Film film)
        {
            _context.Films.Update(film);
        }
    }
}
