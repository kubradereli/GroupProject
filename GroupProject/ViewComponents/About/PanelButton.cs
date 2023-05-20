using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.About
{
    public class PanelButton:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var user = c.Users.Where(x => x.UserMail == userMail).FirstOrDefault();

            User user2 = new User();
            if (user == null)
            {
                user2.UserID = 0;
                user2.UserDateOfBirth = DateTime.Now;
                user2.UserStatus = false;
                user2.RememberMe = false;
                return View(user2);
            }
            else
            {
                return View(user);
            }
        }
    }
}
