﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> movies;
        public MoviesController() {
            movies = new List<Movie>();
            movies.Add(new Movie(1, "Gattaca"));
            movies.Add(new Movie(2, "Aliens"));
            movies.Add(new Movie(3, "LA Confidential"));
        }
        // GET: Movies/Random
        public ActionResult index(){
            var viewModel = new MovieListViewModel(movies);
            return View(viewModel);
        }
        /*
        public ActionResult Random()
        {
            Movie movie = new Movie("Gattaca");
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Customer1"));
            customers.Add(new Customer("Customer2"));
            
            RandomMovieViewModel viewModel = new RandomMovieViewModel(movie, customers);

            return View(viewModel); // devuelve una view pasandole una clase
            //return Content("errrrrrmm yello?"); // devuelve un churro de texto pero dentro de los tags <html><body>
            //return HttpNotFound(); // tipico error de página no encontrada
            //return new EmptyResult(); // devuelve una pagina en blanco // devuelve un churro de texto pero dentro de los tags <html><body>
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); //redirecciona a otro controller/view
        }
        public ActionResult Edit(int id) {


            return Content($"Id: {id}");
        }
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) pageIndex = 1;
            if (string.IsNullOrEmpty(sortBy)) sortBy = "Name";

            return Content($"Page Index: {pageIndex}, Order By: {sortBy}");
        }
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByRealeaseDate(int year, int month)
        {
            return Content($"Year: {year}, Month: {month}");
        }
        */
    }
}