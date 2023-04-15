using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReadingActivityService : IGenericService<ReadingActivity>
    {
        List<ReadingActivity> GetReadingActivitiesListWithBook();

        ReadingActivity GetReadinActivityByIdWithBook(int id);
    }
}
