using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
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
    }
}