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
    public class ContactInformationManager : IContactInformationService
    {
        IContactInformationDal _contactInformationDal;

        public ContactInformationManager(IContactInformationDal contactInformationDal)
        {
            _contactInformationDal = contactInformationDal;
        }

        public void TAdd(ContactInformation t)
        {
            _contactInformationDal.Insert(t);
        }

        public void TDelete(ContactInformation t)
        {
            _contactInformationDal.Delete(t);
        }

        public ContactInformation TGetById(int id)
        {
            return _contactInformationDal.GetByID(id);
        }

        public List<ContactInformation> TGetList()
        {
            return _contactInformationDal.GetListAll();
        }

        public void TUpdate(ContactInformation t)
        {
            _contactInformationDal.Update(t);
        }
    }
}
