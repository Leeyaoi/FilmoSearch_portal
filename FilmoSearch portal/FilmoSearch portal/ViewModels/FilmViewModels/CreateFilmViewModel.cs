using FilmoSearch_portal.ViewModels.ReviewViewModels;
using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.ViewModels.FilmViewModels
{
    public class CreateFilmViewModel
    {
        [MaxLength(20)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [Range(0, 1000000, ErrorMessage = "Impossible year")]
        public int Year { get; set; }
    }
}
