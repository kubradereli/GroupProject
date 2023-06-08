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

        // Kullanıcı panelindeki kitap alıntılarım 
        public IActionResult UserBookQuotesList(string sort)
        {
            var values = bookQuoteManager.GetBookQuoteListWithBook();
            switch (sort)
            {
                case "BookNameASC":
                    values = values.OrderBy(r => r.Book.BookName).ToList();
                    break;
                case "BookNameDESC":
                    values = values.OrderByDescending(r => r.Book.BookName).ToList();
                    break;
                case "DateASC":
                    values = values.OrderByDescending(r => r.BookQuoteDate).ToList();
                    break;
                case "DateDESC":
                    values = values.OrderBy(r => r.BookQuoteDate).ToList();
                    break;
                default:
                    values = values.OrderByDescending(r => r.BookQuoteDate).ToList();
                    break;
            }
            return View(values);
        }

        // Admin panelindeki kitap alıntıları
        public IActionResult BookQuoteStatusList(string sort)
        {
            var values = bookQuoteManager.GetBookQuoteListWithUser();
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

        // Admin panelinde kitap alıntısı aktif/pasif butonu
        public IActionResult BookQuoteStatusChange(int id)
        {
            var value = bookQuoteManager.TGetById(id);
            if (value.BookQuoteStatus == true)
            {
                value.BookQuoteStatus = false;

            }
            else
            {
                value.BookQuoteStatus = true;
            }
            bookQuoteManager.TUpdate(value);

            return RedirectToAction("BookQuoteStatusList");
        }
    }
}
