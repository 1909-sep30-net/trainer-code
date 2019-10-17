using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers
{
    [Route("accounts")] // example of "attribute routing"
    // alternative to endpoint routing, configured globally in the Startup file
    // endpoint routing is preferred for MVC apps. ()
    public class CustomerController : Controller
    {
        // this is an action method
        // each action method is going to correspond to one "URL" for our website
        //    (if there are parameters in that URL, we can handle many values in one action method)
        public IActionResult Index()
        {
            // every action method's job is to fetch data / push data / whatever
            // "action" is represented by this URL that the user is sending a request to

            // and then return some "result"
            //     a result is something that ASP.NET Core can "render" into an HTTP response.
            //    within the MVC world, our results are either ViewResult or some kind of RedirectResult

            // views are the kind of result that renders into HTML.
            // "View()" is a helper method from the base class that looks for
            // a view matching the name of this current action method ("Index"),
            //      for this controller ("Customer").
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Nick Enscala" },
                new Customer { Id = 2, Name = "Fred Belotte" }
            };

            //DynamicTests();

            return View(customers); // this is how you give a view its model
        }

        //[NonAction] // tells MVC this is not an action method
        //private void DynamicTests()
        //{
        //    dynamic dynamicValue = 45;
        //    dynamicValue.Name = "abc";
        //}
    }
}
