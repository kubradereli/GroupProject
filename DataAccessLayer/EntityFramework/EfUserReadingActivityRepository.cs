﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserReadingActivityRepository : GenericRepository<UserReadingActivity>, IUserReadingActivityDal
    {
        public List<UserReadingActivity> GetListWithUser()
        {
            using(var c=new Context())
            {
                return c.UserReadingActivities.Include(x => x.User).ToList();
            }
        }

        public List<UserReadingActivity> GetListofActivityInfo(int userId)
        {
            using (var c = new Context())
            {
                var result =
                from userActivity in c.UserReadingActivities
                join readingActivity in c.ReadingActivities on userActivity.ReadingActivityID equals readingActivity.ReadingActivityID
                where userActivity.UserID == userId
                select new UserReadingActivity{
                    NumberOfPages = userActivity.NumberOfPages,
                    BookReviewScore = userActivity.BookReviewScore,
                    ReadingActivityID = userActivity.ReadingActivityID,
                    UserReadingActivityID = userActivity.UserReadingActivityID,
                    ReadingActivity = readingActivity};
                return result.ToList();

            }
        } 
    }
}
