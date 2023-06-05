using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents
{
    public class ContactInformation :ViewComponent
    {
        ContactInformationManager contactInformationManager = new ContactInformationManager(new EfContactInformationRepository());
        public IViewComponentResult Invoke()
        {
            var values = contactInformationManager.TGetList().FirstOrDefault();
            return View(values);
        }
    }
}
