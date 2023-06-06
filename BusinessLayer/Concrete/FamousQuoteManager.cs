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
    public class FamousQuoteManager : IFamousQuoteService
    {
        IFamousQuoteDal _famousQuoteDal;

        public FamousQuoteManager(IFamousQuoteDal famousQuoteDal)
        {
            _famousQuoteDal = famousQuoteDal;
        }

        public void TAdd(FamousQuote t)
        {
            _famousQuoteDal.Insert(t);
        }

        public void TDelete(FamousQuote t)
        {
            _famousQuoteDal.Delete(t);
        }

        public FamousQuote TGetById(int id)
        {
            return _famousQuoteDal.GetByID(id);
        }

        public List<FamousQuote> TGetList()
        {
            return _famousQuoteDal.GetListAll();
        }

        public void TUpdate(FamousQuote t)
        {
            _famousQuoteDal.Update(t);
        }
    }
}
