using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie_Rent.Models;

namespace Movie_Rent.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() {Name="Shrek !" };
            return View(movie);
        }
    }
}