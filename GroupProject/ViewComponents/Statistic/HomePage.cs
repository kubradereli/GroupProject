using DataAccessLayer.Concrete;
using DevExtreme.AspNet.Data;
using EntityLayer.Concrete.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.Statistic
{
    public class HomePage : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var result = c.Statistics.FromSqlRaw("SELECT COUNT(RA.ReadingActivityID) Deger1, COUNT(URA.UserID) Deger2, (SELECT COUNT(UserID) FROM Users WHERE UserStatus = 1) Deger3, (SELECT COUNT(CommentID) FROM Comments WHERE CommentStatus = 1) Deger4, (SELECT COUNT(BookQuoteID) FROM BookQuotes WHERE BookQuoteStatus=1) Deger5 FROM ReadingActivities RA LEFT OUTER JOIN UserReadingActivities URA ON RA.ReadingActivityID = URA.ReadingActivityID WHERE RA.ActivityStatus = 1").ToList().FirstOrDefault();

            return View(result);
        }
    }
}
