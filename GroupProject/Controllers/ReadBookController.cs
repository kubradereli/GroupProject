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

        public IActionResult BooksIRead()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            var values = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == BookReadStatusEnum.Okundu && s.UserID==userID).OrderBy(x => x.ReadingDate);
            return View(values);
        }

        public IActionResult BooksIWillRead()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            var values = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == BookReadStatusEnum.Okunacak && s.UserID == userID);
            return View(values);
        }

        public IActionResult BooksIWantToBuy()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            var values = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == BookReadStatusEnum.SatınAlınacak && s.UserID == userID);
            return View(values);
        }

        // Okuduğum Kitaplar Sayfası için

        [HttpGet]
        public IActionResult BookAdd()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in categoryManager.TGetList().OrderBy(s=>s.CategoryName)
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
        public IActionResult EditBook(ReadBook p )
        {
       
            Context c = new Context();
            var userMail = User.Identity.Name;
            p.UserID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            p.BookReadStatus = BookReadStatusEnum.Okundu;
            p.Book.BookStatus = true;
            readBookManager.TUpdate(p);
            return RedirectToAction("BooksIRead");
        }

        //

        //Satın Alacağım Kitaplar İçin

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
            readBookManager.TAdd(p);
            return RedirectToAction("BooksIWillRead", "ReadBook");
        }

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
    }
}
