using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.Models
{
    public class Role
    {
        [Display(Name = "Actor:")]
        [ForeignKey("Actor")]
        public int ActorId { get; set; }

        [Display(Name = "Film:")]
        [ForeignKey("Film")]
        public int FilmId { get; set; }

        [Display(Name = "Role:")]
        [Required(ErrorMessage = "Their role is required")]
        [MaxLength(30)]
        public string Title { get; set; } = "";

        public Film? Film { get; set; }
        public Actor? Actor { get; set; }
    }
}
