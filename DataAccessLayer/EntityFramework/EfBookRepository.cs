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
    public class EfBookRepository : GenericRepository<Book>, IBookDal
    {
        public List<Book> GetListWithCategory()
        {
            using(var c= new Context())
            {
                return c.Books.Include(x => x.Category).ToList();
            }
        }
    }
}
