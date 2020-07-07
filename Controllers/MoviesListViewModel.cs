using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.Controllers
{
    internal class MoviesListViewModel
    {
        private List<Movie> movies;

        public MoviesListViewModel(List<Movie> movies)
        {
            this.movies = movies;
        }
    }
}