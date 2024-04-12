using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.Models
{
    public class Actor
    {
        [Display(Name = "id:")]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Their name is required")]
        [MaxLength(50, ErrorMessage = "Too long name, choose another")]
        public string FirstName { get; set; } = "";

        [Display(Name = "Surname:")]
        [Required(ErrorMessage = "Their last name is required")]
        [MaxLength(50, ErrorMessage = "Too long name, choose another")]
        public string LastName { get; set; } = "";

        public virtual List<Role> Roles { get; set; } = new();
        public List<Film> Films { get; set; } = new();
    }
}
