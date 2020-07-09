using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter movies's title")]
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please enter movies's genre")]
        public int GenreId { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Please enter movies's release date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Number of copies in stock")]
        [Required(ErrorMessage = "Please enter number of copies in stock")]
        [Range(1, 20, ErrorMessage = "The number of copies must be between 1 and 20")]
        public int NumberInStock { get; set; }
        [Display(Name = "Number of copies available")]
        [Required(ErrorMessage = "Please enter number of copies available")]
        [Range(1, 20, ErrorMessage = "The number of copies must be between 1 and 20")]
        public int NumberAvailable { get; set; }
    }
}