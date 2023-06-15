using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Enums;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class ReadBookController : Controller
    {
        ReadBookManager readBookManager = new ReadBookManager(new EfReadBookRepository());
        BookManager bookManager = new BookManager(new EfBookRepository());
        private static bool bookSortAsc = false;

        // Kullanıcı paneli - Okuduğum kitaplar listesi
        public IActionResult BooksIRead(string sort)
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var model = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == BookReadStatusEnum.Okundu && s.UserID == userID);

            switch (sort)
            {
                case "BookName":
                    if (bookSortAsc)
                    {
                        model = model.OrderByDescending(r => r.Book.BookName).ToList();
                    }
                    else
                    {
                        model = model.OrderBy(r => r.Book.BookName).ToList();
                    }
                    bookSortAsc = !bookSortAsc;
                    break;
                case "BookNameDESC":
                    break;
                case "BookAuthorASC":
                    model = model.OrderBy(r => r.Book.BookAuthor).ToList();
                    break;
                case "BookAuthorDESC":
                    model = model.OrderByDescending(r => r.Book.BookAuthor).ToList();
                    break;
                case "BookPageCountASC":
                    model = model.OrderBy(r => r.Book.BookPageCount).ToList();
                    break;
                case "BookPageCountDESC":
                    model = model.OrderByDescending(r => r.Book.BookPageCount).ToList();
                    break;
                case "ReadingDateASC":
                    model = model.OrderBy(r => r.ReadingDate).ToList();
                    break;
                case "ReadingDateDESC":
                    model = model.OrderByDescending(r => r.ReadingDate).ToList();
                    break;
                case "CompletionDateASC":
                    model = model.OrderBy(r => r.CompletionDate).ToList();
                    break;
                case "CompletionDateDESC":
                    model = model.OrderByDescending(r => r.CompletionDate).ToList();
                    break;
                default:
                    model = model.OrderByDescending(r => r.CompletionDate).ToList();
                    break;
            }

            return View(model);
        }

        // Kullanıcı paneli - Okuyacağım kitaplar listesi
        public IActionResult BooksIWillRead(string sort)
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var model = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == BookReadStatusEnum.Okunacak && s.UserID == userID);

            switch (sort)
            {
                case "BookNameASC":
                    model = model.OrderBy(r => r.Book.BookName).ToList();
                    break;
                case "BookNameDESC":
                    model = model.OrderByDescending(r => r.Book.BookName).ToList();
                    break;
                case "BookAuthorASC":
                    model = model.OrderBy(r => r.Book.BookAuthor).ToList();
                    break;
                case "BookAuthorDESC":
                    model = model.OrderByDescending(r => r.Book.BookAuthor).ToList();
                    break;
                case "BookPageCountASC":
                    model = model.OrderBy(r => r.Book.BookPageCount).ToList();
                    break;
                case "BookPageCountDESC":
                    model = model.OrderByDescending(r => r.Book.BookPageCount).ToList();
                    break;
                case "ReadingDateASC":
                    model = model.OrderBy(r => r.ReadingDate).ToList();
                    break;
                case "ReadingDateDESC":
                    model = model.OrderByDescending(r => r.ReadingDate).ToList();
                    break;
                default:
                    model = model.OrderByDescending(r => r.ReadingDate).ToList();
                    break;
            }
            return View(model);
        }

        // Kullanıcı Paneli - Okuduğum Kitap Ekleme
        [HttpGet]
        public IActionResult BookAdd()
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
        public IActionResult BookAdd(ReadBook p)
        {

            Context c = new Context();
            var userMail = User.Identity.Name;
            p.UserID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            p.BookReadStatus = BookReadStatusEnum.Okundu;
            p.Book.BookStatus = true;
            //p.ReadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            readBookManager.TAdd(p);
            return RedirectToAction("BooksIRead", "ReadBook");
        }

        // Kullanıcı Paneli - Okuduğum Kitap Güncelleme
        [HttpGet]
        public IActionResult EditBook(int id)
        {
            BookAdd();
            ReadBook readBook = readBookManager.TGetById(id);
            Book book = bookManager.TGetById(readBook.BookID);
            readBook.Book = book;
            return View(readBook);
        }
        [HttpPost]
        public IActionResult EditBook(ReadBook p)
        {

            Context c = new Context();
            var userMail = User.Identity.Name;
            p.UserID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            p.BookReadStatus = BookReadStatusEnum.Okundu;
            p.Book.BookStatus = true;
            readBookManager.TUpdate(p);
            return RedirectToAction("BooksIRead");
        }

        // Kullanıcı Paneli - Okuyacağım Kitap Ekleme
        [HttpGet]
        public IActionResult BooksIWillReadAdd()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in categoryManager.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BooksIWillReadAdd(ReadBook p)
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            p.UserID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            p.BookReadStatus = BookReadStatusEnum.Okunacak;
            p.Book.BookStatus = true;
            p.ReadingDate = DateTime.Now;
            readBookManager.TAdd(p);
            return RedirectToAction("BooksIWillRead", "ReadBook");
        }

        // Kullanıcı Paneli - Okuyacağım Kitap Güncelleme
        [HttpGet]
        public IActionResult BooksIWillReadEdit(int id)
        {
            BooksIWillReadAdd();
            ReadBook readBook = readBookManager.TGetById(id);
            Book book = bookManager.TGetById(readBook.BookID);
            readBook.Book = book;
            return View(readBook);
        }
        [HttpPost]
        public IActionResult BooksIWillReadEdit(ReadBook p)
        {

            Context c = new Context();
            var userMail = User.Identity.Name;
            p.UserID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            p.BookReadStatus = BookReadStatusEnum.Okunacak;
            p.Book.BookStatus = true;
            readBookManager.TUpdate(p);
            return RedirectToAction("BooksIWillRead");
        }

        // Kullanıcı Paneli - Okundu Bilgisi Butona Tıklayınca
        [HttpGet]
        public IActionResult CheckReadBooks(int id)
        {
            BooksIWillReadAdd();
            ReadBook readBook = readBookManager.TGetById(id);
            Book book = bookManager.TGetById(readBook.BookID);
            readBook.Book = book;
            return View(readBook);
        }
        [HttpPost]
        public IActionResult CheckReadBooks(ReadBook p)
        {
            EditBook(p);
            //Context c = new Context();
            //var userMail = User.Identity.Name;
            //p.UserID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            //p.BookReadStatus = BookReadStatusEnum.Okundu;
            //p.Book.BookStatus = true;

            return RedirectToAction("BooksIWillRead");
        }

        // Kullanıcı Paneli - Genel Kitap İstatistikleri
        public IActionResult BookStatistics()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            int userId = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var readBookStatistics = readBookManager.GetReadBookStatistics(userId);

            return View(readBookStatistics);
        }
    }
}
