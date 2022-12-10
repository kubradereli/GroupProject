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
    public class ReadBookManager : IReadBookService
    {
        IReadBookDal _readBookDal;

        public ReadBookManager(IReadBookDal readBookDal)
        {
            _readBookDal = readBookDal;
        }

        public void TAdd(ReadBook t)
        {
            _readBookDal.Insert(t);
        }

        public void TDelete(ReadBook t)
        {
            _readBookDal.Delete(t);
        }

        public ReadBook TGetById(int id)
        {
            return _readBookDal.GetByID(id);
        }

        public List<ReadBook> TGetList()
        {
            return _readBookDal.GetListAll();
        }

        public void TUpdate(ReadBook t)
        {
            _readBookDal.Update(t);
        }
    }
}
