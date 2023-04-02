using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class ReadingActivityController : Controller
    {
        Context c = new Context();
        ReadingActivityManager readingActivityManager = new ReadingActivityManager(new EfReadingActivityRepository());
        BookManager bookManager = new BookManager(new EfBookRepository());

        public IActionResult Index()
        {
            return View();
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
        public IActionResult ActivityAdd(ReadingActivity p)
        {

            Context c = new Context();
            var userMail = User.Identity.Name;
            p.AdminID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            p.ActivityStatus = true;
            p.Book.BookStatus = true;
            p.ActivityCreateDate = DateTime.Now;
            readingActivityManager.TAdd(p);
            return RedirectToAction("ReadingActivityList", "ReadingActivity");
        }
        [HttpGet]
        public IActionResult EditActivity(int id)
        {
            ActivityAdd();
            ReadingActivity readingActivity = readingActivityManager.TGetById(id);
            Book book = bookManager.TGetById(readingActivity.BookID);
            readingActivity.Book = book;
            return View(readingActivity);
        }

        [HttpPost]
        public IActionResult EditActivity(ReadingActivity p)
        {

            Context c = new Context();
            var userMail = User.Identity.Name;
            p.AdminID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            p.Book.BookStatus = true;
            readingActivityManager.TUpdate(p);
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

    }
}
