using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext context;
        public RentalsController()
        {
            context = new ApplicationDbContext();
        }
        // POST /api/rentals
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDTO rental)
        {

            if (rental.movieids.Count == 0) return BadRequest("No movies selected");

            var customer = context.Customers.SingleOrDefault(
                c => c.Id == rental.customerid);

            if (customer == null) return BadRequest("Customer is not valid");

            var movies = context.Movies.Where(
                m => rental.movieids.Contains(m.Id)).ToList();

            if (movies.Count != rental.movieids.Count) return BadRequest("One or more movies are invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest($"Movie {movie.Name} is not available.");

                movie.NumberAvailable--;

                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                context.Rentals.Add(newRental);
            }

            context.SaveChanges();

            return Ok();
        }
    }
}
