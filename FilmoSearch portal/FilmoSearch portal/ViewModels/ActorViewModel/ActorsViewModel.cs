using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.ViewModels.ActorViewModel
{
    public class ActorsViewModel
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Too long name, choose another")]
        public string FirstName { get; set; } = "";

        [MaxLength(50, ErrorMessage = "Too long name, choose another")]
        public string LastName { get; set; } = "";

    }
}
