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
    public class UserReadingActivityManager : IUserReadingActivityService
    {
        IUserReadingActivityDal _userReadingActivityDal;

        public UserReadingActivityManager(IUserReadingActivityDal userReadingActivityDal)
        {
            _userReadingActivityDal = userReadingActivityDal;
        }

        public List<UserReadingActivity> GetUserReadingActivitiesWithUser()
        {
            return _userReadingActivityDal.GetListWithUser();
        }

        public void TAdd(UserReadingActivity t)
        {
            _userReadingActivityDal.Insert(t);
        }

        public void TDelete(UserReadingActivity t)
        {
            _userReadingActivityDal.Delete(t);
        }

        public UserReadingActivity TGetById(int id)
        {
            return _userReadingActivityDal.GetByID(id);
        }

        public List<UserReadingActivity> TGetList()
        {
            return _userReadingActivityDal.GetListAll();
        }

        public void TUpdate(UserReadingActivity t)
        {
            _userReadingActivityDal.Update(t);
        }
    }
}
