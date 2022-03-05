using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Portfolio.Misc.Services.EmailService;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        private ApplicationContext _db;

        public HomeController (ApplicationContext context, IEmailService emailService)
        {
            _emailService = emailService;
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = new Message(new string[] { model.Email }, "Test email", model.Message);
                await _emailService.SendEmailAsync(message);

                var tempMessage = new MessageViewModel
                {
                    Id = Guid.NewGuid(),
                    Email = model.Email,
                    Message = model.Message,
                };
                _db.Messages.Add(tempMessage);
                await _db.SaveChangesAsync();
            }
            return Ok();
        }
    }
}