using FilmoSearch_portal.Models;

namespace FilmoSearch_portal.Interfaces
{
    public interface IActor
    {
        List<Actor> GetAll();
        Actor GetById(int id);
        void Insert(Actor actor);
        void Update(Actor actor);
        void Delete(Actor actor);

    }
}
