using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.Footer
{
    public class FooterContact :ViewComponent
    {
        ContactInformationManager contactInformationManager = new ContactInformationManager(new EfContactInformationRepository());
        public IViewComponentResult Invoke()
        {
            var values = contactInformationManager.TGetList().FirstOrDefault();
            return View(values);
        }
    }
}
