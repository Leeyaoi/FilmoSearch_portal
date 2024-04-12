using FilmoSearch_portal.Models;

namespace FilmoSearch_portal.Interfaces
{
    public interface IPortal
    {
        IActor Actor { get; }
        IFilm Film { get; }
        string Title { get; }

        void Save();
        
    }
}
