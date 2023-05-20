using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutRepository());

        // Hakkımda sayfasındaki bilgiler
        public IActionResult Index()
        {
            var values = aboutManager.TGetList().FirstOrDefault();
            return View(values);
        }

        // Admin panelinde hakkımızda güncelleme sayfası
        [HttpGet]
        public IActionResult EditAbout()
        {
            About about = aboutManager.TGetList().FirstOrDefault();
            return View(about);
        }

        [HttpPost]
        public IActionResult EditAbout(About p)
        {
            aboutManager.TUpdate(p);
            return RedirectToAction("Index");
        }

    }
}
