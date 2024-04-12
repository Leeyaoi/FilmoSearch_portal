using FilmoSearch_portal.Models;

namespace FilmoSearch_portal.Interfaces
{
    public interface IReview
    {
        List<Review> GetReviews(int filmId);
        Review GetById(int id);
        void Insert(Review review);
        void Update(Review review);
        void Delete(Review review);

        IFilm Film {  get; }

    }
}
