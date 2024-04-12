using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.ViewModels.RoleViewModels
{
    public class RoleViewModel
    {
		[Display(Name = "id:")]
		public int Id { get; set; }

		[Display(Name = "Film:")]
		public int FilmId { get; set; }
        public string FilmTitle { get; set; }

        [Display(Name = "Actor:")]
		public int ActorId { get; set; }
        public string ActorName { get; set; }

        [Display(Name = "Role:")]
        [MaxLength(30)]
        public string Title { get; set; } = "";
    }
}
