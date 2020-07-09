using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext context;
        public MoviesController()
        {
            context = new ApplicationDbContext();
        }
        // GET /api/customers
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = context.Movies.Include(m => m.Genre).Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

            var movies = moviesQuery.ToList();


            return Ok(movies);
        }
        // GET /api/customers/1
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = context.Movies.Include(m => m.Genre).Single(m => m.Id == Id);
            if (movie == null) return NotFound();
            else return Ok(movie);
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                movie.NumberAvailable = movie.NumberInStock;
                context.Movies.Add(movie);
                context.SaveChanges();
                return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
            }
        }
        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest();
            else
            {
                var movieToEdit = context.Movies.Single(m => m.Id == Id);
                if (movieToEdit == null) return NotFound();
                else
                {
                    movieToEdit.Name = movie.Name;
                    movieToEdit.GenreId = movie.GenreId;
                    movieToEdit.ReleaseDate = movie.ReleaseDate;
                    movieToEdit.NumberInStock = movie.NumberInStock;
                    movieToEdit.NumberAvailable = movie.NumberAvailable;

                    context.SaveChanges();

                    return Ok(movieToEdit);
                }
            }
        }
        // DELETE /api/customer/1
        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            var movieToDelete = context.Movies.Single(m => m.Id == Id);
            if (movieToDelete == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            else
            {
                context.Movies.Remove(movieToDelete);
                context.SaveChanges();
            }
        }
    }
}
