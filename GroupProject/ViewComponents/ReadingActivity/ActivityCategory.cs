using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.ReadingActivity
{
    public class ActivityCategory:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           

            return View();
        }
    }
}
