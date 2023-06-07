using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using EntityLayer.Enums;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReadBookRepository : GenericRepository<ReadBook>, IReadBookDal
    {
        public List<ReadBook> GetListWithBook()
        {
            using (var c = new Context())
            {
                return c.ReadBooks.Include(x => x.Book.Category).ToList();
            }
        }

        public ReadBookCounts GetReadBookStatistics(int userID)
        {
            using (var c = new Context())
            {
                var result = new ReadBookCounts();

                var readBook = c.ReadBooks.Where(x => x.UserID == userID && x.BookReadStatus == BookReadStatusEnum.Okundu);
                result.ReadBookCount = readBook.Count();
                result.ReadBookPageCount = readBook.Sum(x => x.Book.BookPageCount);

                var willReadBook = c.ReadBooks.Where(x => x.UserID == userID && x.BookReadStatus == BookReadStatusEnum.Okunacak);
                result.WillReadBookCount = willReadBook.Count();
                result.WillReadBookPageCount = willReadBook.Sum(x => x.Book.BookPageCount);

                var attendedActivity = c.UserReadingActivities.Where(x => x.UserID == userID);
                result.AttendedActivityCount = attendedActivity.Count();
                result.AttendedActivityPageCount = attendedActivity.Sum(x => x.NumberOfPages);

                result.CommentCount = c.Comments.Where(x => x.UserID == userID).Count();
                result.QuoteCount= c.BookQuotes.Where(x => x.UserID == userID).Count();

                return result;
            }
        }
    }
}
