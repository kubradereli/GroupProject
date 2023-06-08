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
        }

        // Kullanıcı panelinde etkinlik yorumlarım sayfası
        public IActionResult UserCommentList(string sort)
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var model = commentManager.GetCommentListWithReadingActivity().Where(s=>s.UserID == userID);

            switch (sort)
            {
                case "ActivityNameASC":
                    model = model.OrderBy(r => r.ReadingActivity.ActivityTitle).ToList();
                    break;
                case "ActivityNameDESC":
                    model = model.OrderByDescending(r => r.ReadingActivity.ActivityTitle).ToList();
                    break;
                case "BookNameASC":
                    model = model.OrderBy(r => r.ReadingActivity.Book.BookName).ToList();
                    break;
                case "BookNameDESC":
                    model = model.OrderByDescending(r => r.ReadingActivity.Book.BookName).ToList();
                    break;
                case "ComemntDateASC":
                    model = model.OrderBy(r => r.CommentDate).ToList();
                    break;
                case "CommentDateDESC":
                    model = model.OrderByDescending(r => r.CommentDate).ToList();
                    break;                
                default:
                    model = model.OrderByDescending(r => r.CommentDate).ToList();
                    break;
            }

            return View(model);
        }

        public IActionResult CommentStatusList(string sort)
        {
            var values = commentManager.GetCommentListWithUser();
            switch (sort)
            {
                case "UserASC":
                    values = values.OrderBy(r => r.User.UserName).ToList();
                    break;
                case "UserDESC":
                    values = values.OrderByDescending(r => r.User.UserName).ToList();
                    break;
                default:
                    values = values.OrderBy(r => r.User.UserName).ToList();
                    break;
            }
            return View(values);
        }

        public IActionResult CommentStatusChange(int id)
        {
            var value = commentManager.TGetById(id);
            if (value.CommentStatus == true)
            {
                value.CommentStatus = false;

            }
            else
            {
                value.CommentStatus = true;
            }
            commentManager.TUpdate(value);

            return RedirectToAction("CommentStatusList");
        }
    }
}