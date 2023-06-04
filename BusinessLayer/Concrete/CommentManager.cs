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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(BookQuote t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(BookQuote t)
        {
            _commentDal.Delete(t);
        }

        public BookQuote TGetById(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<BookQuote> TGetList()
        {
            return _commentDal.GetListAll();
        }

        public void TUpdate(BookQuote t)
        {
            _commentDal.Update(t);
        }
    }
}
