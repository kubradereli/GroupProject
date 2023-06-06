using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.ReadingActivity
{
    public class ActivitySubscribers:ViewComponent
    {
        UserReadingActivityManager userReadingActivityManager = new UserReadingActivityManager(new EfUserReadingActivityRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = userReadingActivityManager.GetUserReadingActivitiesWithUser().Where(s=>s.ReadingActivityID == id);  
            
            return View(values);
        }
    }
}
