using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class UserReadingActivityController : Controller
    {
        UserReadingActivityManager userReadingActivityManager = new UserReadingActivityManager(new EfUserReadingActivityRepository());

        [HttpPost]
        public IActionResult UserJoinActivity(UserReadingActivity activity)
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            bool isUserRegistered = c.UserReadingActivities.Any(x => x.UserID == userID);
            if (isUserRegistered)
            {
                // Kullanıcı zaten kayıtlı ise işlemi durdur ve uygun bir yanıt döndür
                return Content("<script>alert('Bu etkinliğe zaten kayıtlı olduğunuz için tekrar kaydolamazsınız.');</script>");

            }

            activity.UserID = userID;
            userReadingActivityManager.TAdd(activity);
            var jsonActivity = JsonConvert.SerializeObject(activity);
            return Json(jsonActivity);
        }
    }
}
