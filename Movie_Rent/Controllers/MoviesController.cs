using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie_Rent.Models;
using Movie_Rent.ViewModels;
using System.Data.Entity;
using System.Linq;
using Movie_Rent.Migrations;

namespace Movie_Rent.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies); 
             }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            return View(movie);

        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "moahmed" };
            var customers = new List<Customer>
            {
                new Customer{Name="customer 1"},
                new Customer{Name="customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie=movie,
                Customers=customers
            };

            return View(viewModel);
        }



        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
            }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Save(Movie Movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(Movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }



            if (Movie.Id == 0)
            {
                Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(Movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == Movie.Id);
                movieInDb.Name = Movie.Name;
                movieInDb.GenreId = Movie.GenreId;
                movieInDb.NumberInStock = Movie.NumberInStock;
                movieInDb.ReleaseDate = Movie.ReleaseDate;
                Console.WriteLine(Movie.Id);
                Console.WriteLine(movieInDb.Name);
            }
            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");


        }

    }
}