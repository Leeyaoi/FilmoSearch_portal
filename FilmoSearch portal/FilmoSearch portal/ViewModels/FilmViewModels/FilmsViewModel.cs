using FilmoSearch_portal.ViewModels.ReviewViewModels;
using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.ViewModels.FilmViewModels
{
    public class FilmsViewModel
    {
        [Display(Name = "Title:")]
        [MaxLength(20)]
        [Required(ErrorMessage = "The title is reqired")]
        public string Title { get; set; } = "";

        [Display(Name = "Description:")]
        [MaxLength(50)]
        [Required(ErrorMessage = "The description is reqired")]
        public string Description { get; set; } = "";

        [Display(Name = "Year:")]
        [Required(ErrorMessage = "The year is reqired")]
        [Range(0, 1000000, ErrorMessage = "Impossible year")]
        public int Year { get; set; }
        public List<ReviewsViewModel> Reviews { get; set; }
    }
}
