using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmoSearch_portal.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Film")]
        [Required(ErrorMessage = "The film is required")]
        public int FilmId { get; set; }

        [Display(Name = "Title:")]
        [MaxLength(30)]
        public string Title { get; set; } = "";

        [Display(Name = "Description:")]
        [Required(ErrorMessage = "The description is required")]
        [MaxLength(100)]
        public string Description { get; set; } = "";

        [Display(Name = "Author:")]
        [Required(ErrorMessage = "The author is required")]
        [MaxLength(30)]
        public string Author { get; set; } = "";

        [Display(Name = "Stars:")]
        [Required(ErrorMessage = "The number of stars is required")]
        [Range(0, 5, ErrorMessage = "Wrong number of stars")]
        public int Stars { get; set; }

        public Film? Film { get; set; }
    }
}
