using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.ViewModels.ReviewViewModels
{
    public class CreateReviewViewModel
    {
		[Display(Name = "Film:")]
		public int FilmId { get; set; }

		[Display(Name = "Film:")]
		public string FilmTitle { get; set; }

		[Display(Name = "Title:")]
        [MaxLength(30)]
        public string Title { get; set; }

		[Display(Name = "Author:")]
        [MaxLength(30)]
        public string Author { get; set; }

		[Display(Name = "Stars:")]
		public int Stars { get; set; }

        [MaxLength(100)]
        [Display(Name = "Description:")]
		public string Description { get; set; }
    }
}
