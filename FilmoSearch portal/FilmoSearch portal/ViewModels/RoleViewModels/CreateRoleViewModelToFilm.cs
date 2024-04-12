using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.ViewModels.RoleViewModels
{
    public class CreateRoleViewModelToFilm
    {
		public int Id { get; set; } = 0;

		[Display(Name = "Film:")]
		public int FilmId { get; set; }
        public string FilmTitle { get; set; }

        [Display(Name = "Actor:")]
		public int ActorId { get; set; }

		[Display(Name = "Role:")]
        [MaxLength(30)]
        public string Title { get; set; } = "";

		public List<SelectListItem> Actors { get; set; }
    }
}
