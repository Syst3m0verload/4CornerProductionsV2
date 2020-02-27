using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _4CornerProductionsV2.Models;
using System.Net.Mail;

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

        [HttpPost]
        public async Task<ActionResult> newClient(Client client)
        {
            try
            {
                // Email: 4cpnotifications@gmail.com
                // Password: 4cornerProds
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new System.Net.NetworkCredential("4cpnotifications@gmail.com", "4cornerProds");
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress("4cpnotifications@gmail.com");
                MailAddress toAddress = new MailAddress("robertbleeme@4cornerproductions.com");

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Timeout = 5000;

                message.From = fromAddress;
                message.To.Add(toAddress);
                message.IsBodyHtml = false;
                message.Subject = "New Client Notification";
                message.Body = 
                    "Name: " + client.Name +
                    "\nEmail: " + client.Email +
                    "\nPhone: " + client.Phone +
                    "\nEvent Type: " + client.Event +
                    "\nComments: " + client.Comment;
                smtpClient.Send(message);
                TempData["msg"] = "<script>alert('Success');</script>";
                return RedirectToAction("Info");
            }
            catch
            {
                TempData["msg"] = "<script>alert('[Error] Please try again or contact me directly at robertbleeme@4cornerproductions.com');</script>";
                return RedirectToAction("Info");
            }

        }
    }
}