using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.Models
{
    public class Film
    {
        [Display(Name = "id:")]
        [Key]
        public int Id { get; set; }

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

        public virtual List<Role> Roles { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public List<Actor> Actors { get; set; } = new();
    }
}
