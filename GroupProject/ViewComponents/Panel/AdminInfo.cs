using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.Panel
{
    public class AdminInfo:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var adminMail = User.Identity.Name;
            var admin = c.Admins.Where(x => x.AdminMail == adminMail).FirstOrDefault();

            return View(admin);
        }
    }
}
