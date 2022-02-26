using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;
using Portfolio.Misc.Services.EmailService;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;

        [HttpGet]
        public IActionResult Index()
        {
            var rng = new Random();

            var message = new Message(new string[] { "ilya-lyapin@mail.ru" }, "Test email", "This is the content from our email.");
            _emailService.SendEmail(message);

           return View();
        }
    }
}