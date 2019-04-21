using System;
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
        [Route("movies/Customers")]
        public ActionResult Customers()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1", Id = 0},
                new Customer {Name = "Customer 2", Id = 1},
                new Customer {Name = "Customer 3", Id = 2}
            };

            var movieList = new CustomersList()
            {
                Customers = customers
            };

            return View(movieList);
        }

        [Route("movies/{id}")]
        public ActionResult Movie()
        {
            var customerList = new List<Customer>()
            {
                new Customer { Id = 1, Name = "Michał" },
                new Customer { Id = 2, Name = "Damian" },
                new Customer { Id = 3, Name = "Agata" }
            };

            var list = new CustomersListForMovie()
            {
                Movie = new Movie() { Id = 0, Name = "Incepcja" },
                Customers = customerList
            };

            return View();
        }

        [Route("movies/")]
        public ActionResult Movies()
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Szybcy i Wściekli 1"},
                new Movie { Id = 2, Name = "Szybcy i Wściekli 2"},
                new Movie { Id = 3, Name = "Szybcy i Wściekli 3"}
            };

            var movieList = new MovieList
            {
                ListOfMovies = movies
            };

            return View(movieList);
        }



        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        { 
            return Content(year + "/"  + month);
        }
    }
}