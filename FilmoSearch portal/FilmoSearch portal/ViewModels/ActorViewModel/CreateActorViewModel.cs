using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.ViewModels.ActorViewModel
{
    public class CreateActorViewModel
    {

        [MaxLength(50, ErrorMessage = "Too long name, choose another")]
        public string FirstName { get; set; } = "";

        [MaxLength(50, ErrorMessage = "Too long name, choose another")]
        public string LastName { get; set; } = "";
    }
}
