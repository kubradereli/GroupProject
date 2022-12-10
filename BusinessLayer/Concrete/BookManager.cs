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
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void TAdd(Book t)
        {
            _bookDal.Insert(t);
        }

        public void TDelete(Book t)
        {
            _bookDal.Delete(t);
        }

        public Book TGetById(int id)
        {
            return _bookDal.GetByID(id);
        }

        public List<Book> TGetList()
        {
            return _bookDal.GetListAll();
        }

        public void TUpdate(Book t)
        {
            _bookDal.Update(t);
        }
    }
}
