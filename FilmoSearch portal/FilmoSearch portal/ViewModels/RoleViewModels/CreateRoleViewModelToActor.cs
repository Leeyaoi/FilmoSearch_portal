using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.ViewModels.RoleViewModels
{
    public class CreateRoleViewModelToActor
    {

        [Display(Name = "Film:")]
        public int FilmId { get; set; }

        [Display(Name = "Actor:")]
        public int ActorId { get; set; }
        public string ActorName { get; set; }

        [Display(Name = "Role:")]
        [MaxLength(30)]
        public string Title { get; set; } = "";

        public List<SelectListItem> Films { get; set; }
    }
}
