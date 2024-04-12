using FilmoSearch_portal.Models;

namespace FilmoSearch_portal.Interfaces
{
    public interface IFilm
    {
        IReview Reviews { get; }
        List<Film> GetAll();
        Film GetById(int id);
        void Insert(Film film);
        void Update(Film film);
        void Delete(Film film);
    }
}
