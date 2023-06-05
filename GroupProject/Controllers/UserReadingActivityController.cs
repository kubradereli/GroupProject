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
        ReadingActivityManager readingActivityManager = new ReadingActivityManager(new EfReadingActivityRepository());
        Context c = new Context();
        private static bool activitySortAsc = false;

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

        // Kullanıcı paneli katıldığım etkinlikler listesi

        public IActionResult ActivityIJoin(string sort)
        {
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var model = userReadingActivityManager.GetListofActivityInfo(userID);
            switch (sort)
            {
                case "ActivityTitle":
                    if (activitySortAsc)
                    {
                        model = model.OrderByDescending(r => r.ReadingActivity.ActivityTitle).ToList();
                    }
                    else
                    {
                        model = model.OrderBy(r => r.ReadingActivity.ActivityTitle).ToList();
                    }
                    activitySortAsc = !activitySortAsc;
                    break;
                case "ActivityTitleDESC":
                    break;
                case "ActivityContentASC":
                    model = model.OrderBy(r => r.ReadingActivity.ActivityContent).ToList();
                    break;
                case "ActivityContentDESC":
                    model = model.OrderByDescending(r => r.ReadingActivity.ActivityContent).ToList();
                    break;
                case "ActivityStartDateASC":
                    model = model.OrderBy(r => r.ReadingActivity.ActivityStartDate).ToList();
                    break;
                case "ActivityStartDateDESC":
                    model = model.OrderByDescending(r => r.ReadingActivity.ActivityStartDate).ToList();
                    break;
                case "ActivityFinishDateASC":
                    model = model.OrderBy(r => r.ReadingActivity.ActivityFinishDate).ToList();
                    break;
                case "ActivityFinishDateDESC":
                    model = model.OrderByDescending(r => r.ReadingActivity.ActivityFinishDate).ToList();
                    break;
                case "NumberOfPagesDateASC":
                    model = model.OrderBy(r => r.NumberOfPages).ToList();
                    break;
                case "NumberOfPagesDESC":
                    model = model.OrderByDescending(r => r.NumberOfPages).ToList();
                    break;
                case "BookReviewScoreASC":
                    model = model.OrderBy(r => r.BookReviewScore).ToList();
                    break;
                case "BookReviewScoreDESC":
                    model = model.OrderByDescending(r => r.BookReviewScore).ToList();
                    break;
                default:
                    model = model.OrderByDescending(r => r.BookReviewScore).ToList();
                    break;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditActivity(int id)
        {
            
            UserReadingActivity userReadingActivity = userReadingActivityManager.TGetById(id);
            return View(userReadingActivity);
        }

        [HttpPost]
        public IActionResult EditActivity(UserReadingActivity p)
        {
            Context c = new Context();           
            userReadingActivityManager.TUpdate(p);
            return RedirectToAction("ActivityIJoin");
        }
    }
}
