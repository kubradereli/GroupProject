using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserReadingActivityDal : IGenericDal<UserReadingActivity>
    {
        List<UserReadingActivity> GetListWithUser();
        List<UserReadingActivity> GetListofActivityInfo(int userId);
    }
}
