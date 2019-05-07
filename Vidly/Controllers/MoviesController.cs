using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyDbContext _context;

        public MoviesController()
        {
            _context = new VidlyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("movies/{id}")]
        public ActionResult Movie()
        {
            //var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View();
        }

        [Route("movies/")]
        public ActionResult Movies()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();
            return View(movie);
        }



        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        { 
            return Content(year + "/"  + month);
        }
    }
}