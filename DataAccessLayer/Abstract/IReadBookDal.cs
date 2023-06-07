using EntityLayer.Concrete;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReadBookDal : IGenericDal<ReadBook>
    {
        List<ReadBook> GetListWithBook();
        ReadBookCounts GetReadBookStatistics(int userID);
    }
}
