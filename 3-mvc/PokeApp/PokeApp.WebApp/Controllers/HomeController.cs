using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeApp.BusinessLogic;
using PokeApp.WebApp.Models;

namespace PokeApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SingletonGuidService _singleton;

        private readonly ScopedGuidService _scoped;

        private readonly TransientGuidService _transient;


        public HomeController(ILogger<HomeController> logger,
            SingletonGuidService singleton,
            ScopedGuidService scoped,
            TransientGuidService transient) // constructor injection
        {
            _logger = logger;
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
        }

        // we can do DI to individual action methods
        // (if it's expensive to initialize that service, and only one aciton method needs)
        public IActionResult Index([FromServices] SingletonGuidService singleton,
            [FromServices] ScopedGuidService scoped,
            [FromServices] TransientGuidService transient)
        {
            // ViewData and friends
            // sometimes, it's not worth it to try and fit every piece of data the view needs into
            // the model / viewmodel.

            // ViewData is basically a dictionary of string to object.
            ViewData["singleton"] = _singleton;
            ViewData["scoped"] = _scoped;
            ViewData["transient"] = _transient;

            ViewData["singleton2"] = singleton;
            ViewData["scoped2"] = scoped;
            ViewData["transient2"] = transient;

            return View();
        }


        // action methods parameters are filled in duirng the "model binding" phase
        // ASP.NET tries to fill them in from - the query string, the form data, the route parameters
        //                                        ?id=12                              /Home/Privacy/12
        public IActionResult Privacy(string login = null)
        {
            if (login != null)
            {
                //ViewBag.Login = login;
                TempData["Login"] = login;
            }

            return View();
        }

        [Authorize]
        public IActionResult Admin()
        {
            return null;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
