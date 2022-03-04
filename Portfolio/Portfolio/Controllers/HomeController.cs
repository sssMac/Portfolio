using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;
using Portfolio.Misc.Services.EmailService;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;

        public HomeController (IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(string adress, string mess)
        { 

            var message = new Message(new string[] { adress }, "Test email", mess);
            await _emailService.SendEmailAsync(message);

            return Ok();
        }
    }
}