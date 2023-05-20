using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.Panel
{
    public class UserInfo:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var user = c.Users.Where(x => x.UserMail == userMail).FirstOrDefault();

            return View(user);
        }
    }
}
