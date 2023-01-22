using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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

        public IActionResult Index()
        {
            var values = bookManager.GetBookListWithCategory();
            return View(values);
        }

        public IActionResult BookDetailsAll(int id)
        {
            
            var values = bookManager.GetBookByID(id);
            return View(values);
        }

    }
}
