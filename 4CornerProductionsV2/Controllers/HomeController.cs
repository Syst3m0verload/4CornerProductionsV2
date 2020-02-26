using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _4CornerProductionsV2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<string> carouselList1 = new List<string>();
            List<string> carouselList2 = new List<string>();
            foreach (var files in Directory.GetFiles("wwwroot/media/Home/carousel1"))
            {
                FileInfo info = new FileInfo(files);
                var fileName = Path.GetFileName(info.FullName);
                carouselList1.Add(fileName);
            }
            foreach (var files in Directory.GetFiles("wwwroot/media/Home/carousel2"))
            {
                FileInfo info = new FileInfo(files);
                var fileName = Path.GetFileName(info.FullName);
                carouselList2.Add(fileName);
            }
            ViewBag.carouselList1 = carouselList1;
            ViewBag.carouselList2 = carouselList2;
            return View();
        }
        [Route("/portfolio")]
        public IActionResult Portfolio()
        {
            List<string> imageList = new List<string>();
            foreach (var files in Directory.GetFiles("wwwroot/media/Portfolio/images"))
            {
                FileInfo info = new FileInfo(files);
                var fileName = Path.GetFileName(info.FullName);
                imageList.Add(fileName);
            }
            ViewBag.images = imageList;
            return View();
        }
        [Route("/info")]
        public IActionResult Info()
        {
            return View();
        }
    }
}