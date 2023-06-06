using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfBookQuoteRepository : GenericRepository<BookQuote>, IBookQuoteDal
    {
        public List<BookQuote> GetListWithBook()
        {
            using (var c = new Context())
            {
                return c.BookQuotes.Include(x => x.Book).ToList();
            }
        }

        public List<BookQuote> GetListWithUser()
        {
            using (var c = new Context())
            {
                return c.BookQuotes.Include(x => x.User).ToList();
            }
        }
    }
}
