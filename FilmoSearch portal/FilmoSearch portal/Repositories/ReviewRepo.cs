using FilmoSearch_portal.Data;
using Microsoft.EntityFrameworkCore;
using FilmoSearch_portal.Interfaces;
using FilmoSearch_portal.Models;

namespace FilmoSearch_portal.Repositories
{
    public class ReviewRepo : IReview
    {
        private readonly PortalContext _context;
        private FilmRepo _filmRepo;

        public ReviewRepo(PortalContext context)
        {
            _context = context;
        }

        public IFilm Film => throw new NotImplementedException();

        public void Delete(Review review)
        {
            _context.Reviews.Remove(review);
        }

        public Review GetById(int id)
        {
            return _context.Reviews.Include(r => r.Film).FirstOrDefault(r => r.Id == id)!;
        }

        public List<Review> GetReviews(int filmId)
        {
            
            return _context.Reviews.Where(review => review.FilmId == filmId).ToList();
        }

        public void Insert(Review review)
        {
            _context.Reviews.Add(review);
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }
    }
}
