using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_Rent.Models;

namespace Movie_Rent.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}