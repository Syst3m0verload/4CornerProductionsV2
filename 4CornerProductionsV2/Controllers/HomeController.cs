using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _4CornerProductionsV2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("/portfolio")]
        public IActionResult Portfolio()
        {
            return View();
        }
        [Route("/info")]
        public IActionResult Info()
        {
            return View();
        }
    }
}