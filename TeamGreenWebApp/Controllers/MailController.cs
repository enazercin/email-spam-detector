using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TeamGreenWebApp.Context;

namespace TeamGreenWebApp.Controllers
{
    public class MailController : Controller
    {

        private readonly TeamGreenDbContext teamGreenDbContext;
        public MailController(TeamGreenDbContext teamGreenDbContext)
        {
            this.teamGreenDbContext = teamGreenDbContext;
        }

        public IActionResult Content(int Id)
        {
            var result = teamGreenDbContext.Mail
                .Include(x => x.User)
                .Include(y => y.Reciver)
                .Where(x => x.Id == Id).FirstOrDefault();

            return View(result);
        }
    }
}
