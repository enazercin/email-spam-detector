using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TeamGreenWebApp.Context;
using TeamGreenWebApp.Service;

namespace TeamGreenWebApp.Controllers
{
    public class LoginController : Controller
    {

        private readonly TeamGreenDbContext teamGreenDbContext;
        public LoginController(TeamGreenDbContext teamGreenDbContext)
        {
            this.teamGreenDbContext = teamGreenDbContext;
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPost(string mail , string password)
        {
            if (string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("mail or password is null or empty!");
            }

            var result = teamGreenDbContext.Users.Where(x => x.MailAddress == mail.Trim() && x.Password == password.Trim()).FirstOrDefault();

            if (result == null)
            {
                throw new Exception("mail or password incorrect!");
            }

            HttpContext.Session.SetString("userName", (result.Name + ' ' + result.Surname));
            HttpContext.Session.SetString("userMailAddress", result.MailAddress);
            HttpContext.Session.SetInt32("userId", result.Id);

            return RedirectToAction("Inbox", "Mailbox");

        }

        public IActionResult UserLogout()
        {
            HttpContext.Session.Remove("userEmail");
            HttpContext.Session.Clear();
            return RedirectToAction("UserLogin", "Login");
        }
    }
}
