using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.Join
{
    public class JoinButton:ViewComponent
    {
        UserReadingActivityManager userReadingActivityManager = new UserReadingActivityManager(new EfUserReadingActivityRepository());

        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userId = c.Users.Where(x => x.UserMail == userMail).FirstOrDefault().UserID;

            var values = userReadingActivityManager.TGetList().Where(s=>s.UserID == userId).FirstOrDefault();

            UserReadingActivity userReadingActivity = new UserReadingActivity();
            if(values == null)
            {
                userReadingActivity.UserReadingActivityID = 0;
                return View(userReadingActivity);
            }
            else
            {
                return View(values);
            }            
        }
    }
}
