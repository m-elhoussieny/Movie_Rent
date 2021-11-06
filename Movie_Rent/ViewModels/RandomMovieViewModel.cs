using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_Rent.Models;

namespace Movie_Rent.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}