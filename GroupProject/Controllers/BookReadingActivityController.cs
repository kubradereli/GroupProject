using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class BookReadingActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
