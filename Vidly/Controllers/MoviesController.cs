﻿using System;
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

        [Route("movies/")]
        public ActionResult Movies()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();
            return View(movie);
        }

        [Route("movies/{id}")]
        public ActionResult Movie(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null) return HttpNotFound();

            return View(movie);
        }

        [Route("movies/new")]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var modelView = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", modelView);
        }

        [Route("movies/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [Route("movies/save")]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate.Date;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        { 
            return Content(year + "/"  + month);
        }
    }
}