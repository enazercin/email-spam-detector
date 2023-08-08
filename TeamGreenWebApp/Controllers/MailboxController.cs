using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TeamGreenWebApp.Context;

namespace TeamGreenWebApp.Controllers
{
    public class MailboxController : Controller
    {
        private readonly TeamGreenDbContext teamGreenDbContext;
        public MailboxController(TeamGreenDbContext teamGreenDbContext)
        {
            this.teamGreenDbContext = teamGreenDbContext;
        }

        public IActionResult Inbox()
        {
            var userMailAddress = HttpContext.Session.GetString("userMailAddress");

            var userId = teamGreenDbContext.Users.Where(x => x.MailAddress == userMailAddress).FirstOrDefault().Id;

            var inboxResult = teamGreenDbContext.Mail
                .Include(x => x.User)
                .Include(x=> x.Reciver)
                .Where(x =>x.IsSpam == false && x.IsActive == true && x.ReciverId == userId)
                .ToList();
           
            return View(inboxResult);

        }

        public IActionResult DeleteMail(int Id)
        {
            var mail = teamGreenDbContext.Mail.Where(x=> x.Id == Id).FirstOrDefault();
            mail.IsActive = false;

            var updateMail = teamGreenDbContext.Update(mail);
            teamGreenDbContext.SaveChanges();

            return RedirectToAction("Inbox", "Mailbox");
        }

        public IActionResult TrashMails()
        {
            var userMailAddress = HttpContext.Session.GetString("userMailAddress");

            var userId = teamGreenDbContext.Users.Where(x => x.MailAddress == userMailAddress).FirstOrDefault().Id;

            var inboxResult = teamGreenDbContext.Mail
                .Include(x => x.User)
                .Include(x => x.Reciver)
                .Where(x => x.IsSpam == false && x.IsActive == false && x.ReciverId == userId)
                .ToList();

            return View(inboxResult);
        }

        public IActionResult SpamMails()
        {
            var userMailAddress = HttpContext.Session.GetString("userMailAddress");

            var userId = teamGreenDbContext.Users.Where(x => x.MailAddress == userMailAddress).FirstOrDefault().Id;

            var inboxResult = teamGreenDbContext.Mail
                .Include(x => x.User)
                .Include(x => x.Reciver)
                .Where(x => x.IsSpam == true && x.IsActive == true && x.ReciverId == userId)
                .ToList();

            return View(inboxResult);
        }

    }
}
