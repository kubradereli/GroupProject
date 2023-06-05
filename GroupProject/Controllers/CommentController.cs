using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        UserManager userManager = new UserManager(new EfUserRepository());

        [HttpGet]

        public PartialViewResult PartialAddComment(int id)
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var model = userManager.TGetById(userID);
            ViewData["Ad"] = model.UserName;
            ViewData["Soyad"] = model.UserSurname;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialAddComment(Comment p, int id)
        {
            p.CommentDate = DateTime.Now;
            p.CommentStatus = true;
            p.ReadingActivityID = id;
            Context c = new Context();
            var userMail = User.Identity.Name;
            p.UserID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            commentManager.TAdd(p);
            Response.Redirect("/ReadingActivity/ReadingActivityDetailsAll/" + id);
            return PartialView();

            //return new ReadingActivityController().ReadingActivityDetailsAll(2);
            //return RedirectToAction("ReadingActivityDetailsAll", "/ReadingActivity/ReadingActivityDetailsAll/2/", new ReadingActivity() { ReadingActivityID = 2});
        }
    }
}
