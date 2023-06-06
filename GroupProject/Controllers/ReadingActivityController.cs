using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using GroupProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class ReadingActivityController : Controller
    {
        Context c = new Context();
        ReadingActivityManager readingActivityManager = new ReadingActivityManager(new EfReadingActivityRepository());
        BookManager bookManager = new BookManager(new EfBookRepository());
        CommentManager commentManager = new CommentManager(new EfCommentRepository());


        public IActionResult Index()
        {
            var values = readingActivityManager.GetReadingActivitiesListWithBook().Where(s => s.ActivityStatus == true).OrderByDescending(s => s.ActivityCreateDate).ToList();
            return View(values);
        }
        public IActionResult ReadingActivityList(string sort)
        {
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var model = readingActivityManager.GetReadingActivitiesListWithBook();
            switch (sort)
            {
                case "ActivityNameASC":
                    model = model.OrderBy(r => r.ActivityTitle).ToList();
                    break;
                case "ActivityNameDESC":
                    model = model.OrderByDescending(r => r.ActivityTitle).ToList();
                    break;
                case "BookNameASC":
                    model = model.OrderBy(r => r.Book.BookName).ToList();
                    break;
                case "BookNameDESC":
                    model = model.OrderByDescending(r => r.Book.BookName).ToList();
                    break;
                case "BookPageCountASC":
                    model = model.OrderBy(r => r.Book.BookPageCount).ToList();
                    break;
                case "BookPageCountDESC":
                    model = model.OrderByDescending(r => r.Book.BookPageCount).ToList();
                    break;
                case "StartDateASC":
                    model = model.OrderByDescending(r => r.ActivityStartDate).ToList();
                    break;
                case "StartDateDESC":
                    model = model.OrderBy(r => r.ActivityStartDate).ToList();
                    break;
                case "FinishDateASC":
                    model = model.OrderByDescending(r => r.ActivityFinishDate).ToList();
                    break;
                case "FinishDateDESC":
                    model = model.OrderBy(r => r.ActivityFinishDate).ToList();
                    break;
                default:
                    model = model.OrderBy(r => r.ActivityStartDate).ToList();
                    break;
            }

            return View(model);

        }
        [HttpGet]
        public IActionResult ActivityAdd()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in categoryManager.TGetList().OrderBy(s => s.CategoryName)
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult ActivityAdd(AddActivityImage p)
        {

            if (p.ActivityImage != null)
            {
                var extension = Path.GetExtension(p.ActivityImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Tema/assets/img/kitap-img", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.ActivityImage.CopyTo(stream);
                p.ReadingActivity.ActivityImage = Path.Combine("/Tema/assets/img/kitap-img", newImageName);
                p.ReadingActivity.Book.BookCoverImage = Path.Combine("/Tema/assets/img/kitap-img", newImageName);
            }

            var userMail = User.Identity.Name;
            p.ReadingActivity.AdminID = c.Admins.Where(x => x.AdminMail == userMail).Select(y => y.AdminID).FirstOrDefault();
            p.ReadingActivity.ActivityStatus = true;
            p.ReadingActivity.Book.BookStatus = true;
            p.ReadingActivity.ActivityCreateDate = DateTime.Now;
            readingActivityManager.TAdd(p.ReadingActivity);
            return RedirectToAction("ReadingActivityList", "ReadingActivity");
        }
        [HttpGet]
        public IActionResult EditActivity(int id)
        {
            ActivityAdd();
            ReadingActivity readingActivity = readingActivityManager.TGetById(id);
            Book book = bookManager.TGetById(readingActivity.BookID);
            readingActivity.Book = book;
            AddActivityImage addActivityImage = new AddActivityImage() 
            {
                ReadingActivity = readingActivity
            };
            return View(addActivityImage);
        }

        [HttpPost]
        public IActionResult EditActivity(AddActivityImage p)
        {
            if (p.ActivityImage != null)
            {
                var extension = Path.GetExtension(p.ActivityImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Tema/assets/img/kitap-img", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.ActivityImage.CopyTo(stream);
                p.ReadingActivity.ActivityImage = Path.Combine("/Tema/assets/img/kitap-img", newImageName);
                p.ReadingActivity.Book.BookCoverImage = Path.Combine("/Tema/assets/img/kitap-img", newImageName);

            }
            var userMail = User.Identity.Name;
            p.ReadingActivity.AdminID = c.Admins.Where(x => x.AdminMail == userMail).FirstOrDefault().AdminID;
            p.ReadingActivity.Book.BookStatus = true;
            readingActivityManager.TUpdate(p.ReadingActivity);
            return RedirectToAction("ReadingActivityList");
        }
        public IActionResult DeleteActivity(int id)
        {

            var value = readingActivityManager.TGetById(id);
            if (value.ActivityStatus == true)
            {
                value.ActivityStatus = false;

            }
            else
            {
                value.ActivityStatus = true;
            }
            readingActivityManager.TUpdate(value);

            return RedirectToAction("ReadingActivityList");
        }

        public IActionResult ReadingActivityDetailsAll(int id)
        {
            var values = readingActivityManager.GetReadinActivityByIdWithBook(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult ReadingActivityAddComment(Comment p, int id)
        {
            p.CommentDate = DateTime.Now;
            p.CommentStatus = true;
            p.ReadingActivityID = id;
            var userMail = User.Identity.Name;
            p.UserID = new Context().Users.
                Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            commentManager.TAdd(p);

            return RedirectToAction("ReadingActivityDetailsAll", "ReadingActivity", new { @id = id });
        }
    }
}