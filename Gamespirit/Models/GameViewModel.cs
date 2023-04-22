using Gamespirit.Data.DbModels;
using System.ComponentModel.DataAnnotations;

namespace Gamespirit.Models
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage ="Please insert a Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please insert a Description")]
        public string Description { get; set; }
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please insert a Genre")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Please insert a Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Please insert a Cover Image Url")]
        public string CoverImageUrl { get; set; }
        [Required(ErrorMessage = "Please insert a Trailer Url")]
        public string TrailerUrl { get; set; }
    }
}
