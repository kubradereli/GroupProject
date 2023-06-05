using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReadingActivityManager : IReadingActivityService
    {
        IReadingActivityDal _readingActivityDal;

        public ReadingActivityManager(IReadingActivityDal readingActivityDal)
        {
            _readingActivityDal = readingActivityDal;
        }

      
        public void TAdd(ReadingActivity t)
        {
            _readingActivityDal.Insert(t);
        }

        public void TDelete(ReadingActivity t)
        {
            _readingActivityDal.Delete(t);
        }

        public ReadingActivity TGetById(int id)
        {
            return _readingActivityDal.GetByID(id);
        }

        public List<ReadingActivity> TGetList()
        {
            return _readingActivityDal.GetListAll();
        }

        public List<ReadingActivity> GetListFromListofIds(List<int> readingActivityIds)
        {
            return _readingActivityDal.GetListAll(x => readingActivityIds.Contains(x.ReadingActivityID));
        }

        public void TUpdate(ReadingActivity t)
        {
            _readingActivityDal.Update(t);
        }

        public List<ReadingActivity> GetReadingActivitiesListWithBook()
        {
            return _readingActivityDal.GetListWithBook();
        }

        public ReadingActivity GetReadinActivityByIdWithBook(int id)
        {
            return _readingActivityDal.GetByIdWithBook(id);
        }

        public List<CategoryCount> GetCountofCategoriesFromActivity()
        {
            return _readingActivityDal.GetCountofCategoriesFromActivity();
        }
    }
}
