using DataAccessLayer.Abstract;
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
    public class EfReadingActivityRepository : GenericRepository<ReadingActivity>, IReadingActivityDal
    {
        public List<ReadingActivity> GetListWithBook()
        {
            using (var c = new Context())
            {
                return c.ReadingActivities.Include(x => x.Book.Category).ToList();
            }
        }

        public ReadingActivity GetByIdWithBook(int id)
        {
            using (var c = new Context())
            {
                return c.ReadingActivities.Include(x => x.Book.Category).Where(s=>s.ReadingActivityID == id).FirstOrDefault();
            }
        }
    }
}
