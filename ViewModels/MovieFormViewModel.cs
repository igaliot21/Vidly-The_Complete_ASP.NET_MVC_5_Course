using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        public MovieFormViewModel() { }
        public MovieFormViewModel(Movie Movie, IEnumerable<Genre> Genres) {
            this.Movie = Movie;
            this.Genres = Genres;
        }
    }
}