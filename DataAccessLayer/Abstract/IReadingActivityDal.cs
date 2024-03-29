﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReadingActivityDal : IGenericDal<ReadingActivity>
    {
        List<ReadingActivity> GetListWithBook();

        ReadingActivity GetByIdWithBook(int id);
        List<CategoryCount> GetCountofCategoriesFromActivity();
    }
}
