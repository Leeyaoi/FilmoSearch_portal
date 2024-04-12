using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.ViewModels.ReviewViewModels
{
    public class ReviewsViewModel
    {
		[Display(Name = "Film:")]
		public int FilmId { get; set; }

		[Display(Name = "Film:")]
		public string FilmTitle { get; set; }

		[Display(Name = "id:")]
		public int Id { get; set; }

		[Display(Name = "Title:")]
		public string Title { get; set; }

		[Display(Name = "Author:")]
		public string Author { get; set; }

		[Display(Name = "Stars:")]
		public int Stars { get; set; }

		[Display(Name = "Description:")]
		public string Description { get; set; }

    }
}
