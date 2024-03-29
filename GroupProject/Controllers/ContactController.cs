﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactRepository());
        ContactInformationManager contactInformationManager = new ContactInformationManager(new EfContactInformationRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        
        // Admin panelinde kullanıcıdan gelen mesajların listelenmesi
        public IActionResult IncomingMessages(string sort, string sort2)
        {
            var model = contactManager.GetContactListWithUser();

            switch (sort)
            {
                case "UserNameSurnameASC":
                    model = model.OrderBy(r => r.User.UserName).ToList();
                    break;
                case "UserNameSurnameDESC":
                    model = model.OrderByDescending(r => r.User.UserName).ToList();
                    break;
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
                    model = model.Where(s => s.ContactStatus == true).ToList();
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

        // Admin paneli - Kullanıcıdan gelen mesajın okundu/okunmadı bilgisini değiştirme
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

        // Vitrin panel - mesaj gönderme işlemi - iletişim sayfası
        [HttpGet]
        public IActionResult AddMessage()
        {
            Context c = new Context();
            var mail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == mail).Select(y => y.UserID).FirstOrDefault();
            var adminID = c.Admins.Where(x => x.AdminMail == mail).Select(y => y.AdminID).FirstOrDefault();
            if (userID != null && userID != 0)
            {
                var model = userManager.TGetById(userID);
                ViewData["Ad"] = model.UserName;
                ViewData["Soyad"] = model.UserSurname;
                ViewData["Mail"] = model.UserMail;
            }
            else if (adminID != null)
            {
                var model = c.Admins.Where(x => x.AdminID == adminID).FirstOrDefault();
                ViewData["Ad"] = model.AdminUserName;
                ViewData["Soyad"] = "";
                ViewData["Mail"] = model.AdminMail;
            }

            List<SelectListItem> subjects = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Öneri", Value = "Öneri" },
                new SelectListItem { Text = "İstek", Value = "İstek" },
                new SelectListItem { Text = "Kitap Etkinliği Önerisi", Value = "Kitap Etkinliği Önerisi" },
                new SelectListItem { Text = "Şikayet", Value = "Şikayet" },
                new SelectListItem { Text = "Diğer", Value = "Diğer" },
            };
            ViewBag.Subjects = subjects;

            return View();
        }
        [HttpPost]
        public IActionResult AddMessage(Contact p)
        {
            Context c = new Context();
            var mail = User.Identity.Name;
            var user = c.Users.Where(x => x.UserMail == mail).FirstOrDefault();
            var admin = c.Admins.Where(x => x.AdminMail == mail).FirstOrDefault();

            Contact contact = new Contact();
            if (user !=null)
            {
                contact.UserID = user.UserID;
            }
            else if (admin!=null)
            {
                contact.UserID = admin.AdminID;
            }
            
            contact.ContactSubject = p.ContactSubject;
            contact.ContactMessage = p.ContactMessage;
            contact.ContactDate = DateTime.Now;
            contact.ContactStatus = false;
            contactManager.TUpdate(contact);
            return RedirectToAction("Index", "About");
        }

        // Admin panelin - iletişim bilgileri güncelleme sayfası
        [HttpGet]
        public IActionResult EditContact()
        {
            ContactInformation contactInformation = contactInformationManager.TGetList().FirstOrDefault();
            return View(contactInformation);
        }
        [HttpPost]
        public IActionResult EditContact(ContactInformation p)
        {
            contactInformationManager.TUpdate(p);
            return RedirectToAction("AddMessage", "Contact");
        }

        // *
        public IActionResult Index()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var model = userManager.TGetById(userID);
            return View(model);
        }
    }    
}