using FilmoSearch_portal.ViewModels.ReviewViewModels;

namespace FilmoSearch_portal.ViewModels.FilmViewModels
{
    public class FilmsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public List<ReviewsViewModel> Reviews { get; set; }
    }
}
