using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult BooksIRead()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            var values = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == 1 && s.UserID==userID);
            return View(values);
        }

        public IActionResult BooksIWillRead()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            var values = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == 2 && s.UserID == userID);
            return View(values);
        }

        public IActionResult BooksIWantToBuy()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            var values = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == 3 && s.UserID == userID);
            return View(values);
        }

    }
}
