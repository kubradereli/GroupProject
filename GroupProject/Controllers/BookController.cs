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
    public class BookController : Controller
    {
        BookManager bookManager = new BookManager(new EfBookRepository());
        BookQuoteManager bookQuoteManager = new BookQuoteManager(new EfBookQuoteRepository());
        ReadingActivityManager readingActivityManager = new ReadingActivityManager(new EfReadingActivityRepository());

        public IActionResult Index()
        {
            var values = readingActivityManager.GetReadingActivitiesListWithBook();
            return View(values);
        }

        public IActionResult BookDetailsAll(int id)
        {
            var values = bookManager.GetBookListWithCategory().Where(s=>s.BookID == id).FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public IActionResult BookQuoteAdd(BookQuote p, int id)
        {
            p.BookQuoteDate = DateTime.Now;
            p.BookQuoteStatus = true;
            p.BookID= id;
            var userMail = User.Identity.Name;
            p.UserID = new Context().Users.
                Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            bookQuoteManager.TAdd(p);

            return RedirectToAction("BookDetailsAll", "Book", new { @id = id });

        }
    }
}
