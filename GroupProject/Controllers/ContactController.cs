using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
      
        public IActionResult Index()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var model = userManager.TGetById(userID);
            return View(model);
        }

        // Admin panelinde kullanıcıdan gelen mesajların listelenmesi
        public IActionResult IncomingMessages(string sort,string sort2)
        {
            var model = contactManager.GetContactListWithUser();

            switch (sort)
            {
                //case "UserNameSurnameASC":
                //    model = model.OrderBy(r => r.ContactName).ToList();
                //    break;
                //case "UserNameSurnameDESC":
                //    model = model.OrderByDescending(r => r.ContactName).ToList();
                    //break;
                case "SubjectASC":
                    model = model.OrderBy(r => r.ContactSubject).ToList();
                    break;
                case "SubjectDESC":
                    model = model.OrderByDescending(r => r.ContactSubject).ToList();
                    break;
                case "DateASC":
                    model = model.OrderByDescending(r => r.ContactDate).ToList();
                    break;
                case "DateDESC":
                    model = model.OrderBy(r => r.ContactDate).ToList();
                    break;
                default:
                    model = model.OrderByDescending(r => r.ContactDate).ToList();
                    break;
            }

            switch (sort2)
            {
                case "StatusActive":
                    model = model.Where(s=>s.ContactStatus == true).ToList();
                    break;
                case "StatusPassive":
                    model = model.Where(s => s.ContactStatus == false).ToList();
                    break;
                case "StatusAll":
                    model = model.ToList();
                    break;
                default:
                    model = model.ToList();
                    break;
            }

            return View(model);
        }

        // Kullanıcıdan gelen mesajın okundu/okunmadı bilgisini değiştirme
        public IActionResult ChangeContactStatus(int id)
        {
            var value = contactManager.TGetById(id);
            if (value.ContactStatus == true)
                value.ContactStatus = false;
            else
                value.ContactStatus = true;
            contactManager.TUpdate(value);

            return RedirectToAction("IncomingMessages");
        }

        // Siteden mesaj gönderme işlemi 
        [HttpGet]
        public IActionResult AddMessage()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var model = userManager.TGetById(userID);
            ViewData["Ad"] = model.UserName;
            ViewData["Soyad"] = model.UserSurname;
            ViewData["Mail"] = model.UserMail;
            return View();
        }
        [HttpPost]
        public IActionResult AddMessage(Contact p)
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var user = c.Users.Where(x => x.UserMail == userMail).FirstOrDefault();

            Contact contact = new Contact();
            contact.UserID = user.UserID;
            contact.ContactSubject = p.ContactSubject;
            contact.ContactMessage = p.ContactMessage;
            contact.ContactDate = DateTime.Now;
            contact.ContactStatus = false;
            contactManager.TUpdate(contact);
            return RedirectToAction("Index", "About");
        }
    }
}
