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
    public class BookQuoteManager : IBookQuoteService
    {
        IBookQuoteDal _bookQuoteDal;

        public BookQuoteManager(IBookQuoteDal bookQuoteDal)
        {
            _bookQuoteDal = bookQuoteDal;
        }

        public List<BookQuote> GetBookQuoteListWithBook()
        {
            return _bookQuoteDal.GetListWithBook();
        }

        public List<BookQuote> GetBookQuoteListWithUser()
        {
            return _bookQuoteDal.GetListWithUser();
        }

        public void TAdd(BookQuote t)
        {
            _bookQuoteDal.Insert(t);
        }

        public void TDelete(BookQuote t)
        {
            _bookQuoteDal.Delete(t);
        }

        public BookQuote TGetById(int id)
        {
            return _bookQuoteDal.GetByID(id);
        }

        public List<BookQuote> TGetList()
        {
            return _bookQuoteDal.GetListAll();
        }

        public void TUpdate(BookQuote t)
        {
            _bookQuoteDal.Update(t);
        }
    }
}
