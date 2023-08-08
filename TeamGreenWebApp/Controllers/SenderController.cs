using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TeamGreenWebApp.Context;
using TeamGreenWebApp.Models;
using Microsoft.AspNetCore.Http;
using TeamGreenWebApp.Service;
using System.Threading.Tasks;

namespace TeamGreenWebApp.Controllers
{
    public class SenderController : Controller
    {
        private readonly TeamGreenDbContext teamGreenDbContext;
        public SenderController(TeamGreenDbContext teamGreenDbContext)
        {
            this.teamGreenDbContext = teamGreenDbContext;
        }

        public IActionResult SendMail()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendMailPost(string userName, string header, string content)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(header) || string.IsNullOrWhiteSpace(content))
            {
                throw new Exception("required places can not be empty!");
            }

            var reciverId = teamGreenDbContext.Reciver.Where(x => x.MailAddress == userName).FirstOrDefault().Id;

            if (reciverId < 0)
            {
                throw new Exception("this mail address can not find!");
            }

            var userId = HttpContext.Session.GetInt32("userId");

            SpamService spam = new SpamService();

            var resultSpam = await spam.InvokeRequestResponseService(header);

            if (resultSpam)
            {
                header = header.Replace(header, $"[SPAM]{header}");
            }

            Mail mail = new Mail
            {
                MailHeader = header,
                MailContent = content,
                IsActive = true,
                IsSpam = resultSpam,
                ReciverId = reciverId,
                CreatedDate = DateTime.Now,
                UserId = userId
            };

            var addNewMail = teamGreenDbContext.Mail.Add(mail);
            teamGreenDbContext.SaveChanges();

            return RedirectToAction("Inbox", "Mailbox");
        }
    }
}
