using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using GroupProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());

        [HttpGet]
        public IActionResult Index()
        {

            //List<SelectListItem> cityvalues = (from x in um.TGetList().OrderBy(s => s.UserCity)
            //                                       select new SelectListItem
            //                                       {
            //                                           Text = x.UserCity,
            //                                           Value = x.UserCity.ToString()
            //                                       }).ToList();
            //ViewBag.cv = cityvalues;
            //return View();

            List<SelectListItem> cities = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Adana", Value = "Adana" },
                new SelectListItem { Text = "Adıyaman", Value = "Adıyaman" },
                new SelectListItem { Text = "Afyonkarahisar", Value = "Afyonkarahisar" },
                new SelectListItem { Text = "Ağrı", Value = "Ağrı" },
                new SelectListItem { Text = "Amasya", Value = "Amasya" },
                new SelectListItem { Text = "Ankara", Value = "Ankara" },
                new SelectListItem { Text = "Antalya", Value = "Antalya" },
                new SelectListItem { Text = "Ardahan", Value = "Ardahan" },
                new SelectListItem { Text = "Artvin", Value = "Artvin" },
                new SelectListItem { Text = "Aydın", Value = "Aydın" },
                new SelectListItem { Text = "Balıkesir", Value = "Balıkesir" },
                new SelectListItem { Text = "Bartın", Value = "Bartın" },
                new SelectListItem { Text = "Batman", Value = "Batman" },
                new SelectListItem { Text = "Bayburt", Value = "Bayburt" },
                new SelectListItem { Text = "Bilecik", Value = "Bilecik" },
                new SelectListItem { Text = "Bingöl", Value = "Bingöl" },
                new SelectListItem { Text = "Bitlis", Value = "Bitlis" },
                new SelectListItem { Text = "Bolu", Value = "Bolu" },
                new SelectListItem { Text = "Burdur", Value = "Burdur" },
                new SelectListItem { Text = "Bursa", Value = "Bursa" },
                new SelectListItem { Text = "Çanakkale", Value = "Çanakkale" },
                new SelectListItem { Text = "Çankırı", Value = "Çankırı" },
                new SelectListItem { Text = "Çorum", Value = "Çorum" },
                new SelectListItem { Text = "Denizli", Value = "Denizli" },
                new SelectListItem { Text = "Diyarbakır", Value = "Diyarbakır" },
                new SelectListItem { Text = "Düzce", Value = "Düzce" },
                new SelectListItem { Text = "Edirne", Value = "Edirne" },
                new SelectListItem { Text = "Elazığ", Value = "Elazığ" },
                new SelectListItem { Text = "Erzincan", Value = "Erzincan" },
                new SelectListItem { Text = "Erzurum", Value = "Erzurum" },
                new SelectListItem { Text = "Eskişehir", Value = "Eskişehir" },
                new SelectListItem { Text = "Gaziantep", Value = "Gaziantep" },
                new SelectListItem { Text = "Giresun", Value = "Giresun" },
                new SelectListItem { Text = "Gümüşhane", Value = "Gümüşhane" },
                new SelectListItem { Text = "Hakkari", Value = "Hakkari" },
                new SelectListItem { Text = "Hatay", Value = "Hatay" },
                new SelectListItem { Text = "Iğdır", Value = "Iğdır" },
                new SelectListItem { Text = "Isparta", Value = "Isparta" },
                new SelectListItem { Text = "İstanbul", Value = "İstanbul" },
                new SelectListItem { Text = "İzmir", Value = "İzmir" },
                new SelectListItem { Text = "Kahramanmaraş", Value = "Kahramanmaraş" },
                new SelectListItem { Text = "Karabük", Value = "Karabük" },
                new SelectListItem { Text = "Karaman", Value = "Karaman" },
                new SelectListItem { Text = "Kars", Value = "Kars" },
                new SelectListItem { Text = "Kastamonu", Value = "Kastamonu" },
                new SelectListItem { Text = "Kayseri", Value = "Kayseri" },
                new SelectListItem { Text = "Kırıkkale", Value = "Kirikkale" },
                new SelectListItem { Text = "Kırklareli", Value = "Kirklareli" },
                new SelectListItem { Text = "Kırşehir", Value = "Kirsehir" },
                new SelectListItem { Text = "Kilis", Value = "Kilis" },
                new SelectListItem { Text = "Kocaeli", Value = "Kocaeli" },
                new SelectListItem { Text = "Konya", Value = "Konya" },
                new SelectListItem { Text = "Kütahya", Value = "Kutahya" },
                new SelectListItem { Text = "Malatya", Value = "Malatya" },
                new SelectListItem { Text = "Manisa", Value = "Manisa" },
                new SelectListItem { Text = "Mardin", Value = "Mardin" },
                new SelectListItem { Text = "Mersin", Value = "Mersin" },
                new SelectListItem { Text = "Muğla", Value = "Mugla" },
                new SelectListItem { Text = "Muş", Value = "Mus" },
                new SelectListItem { Text = "Nevşehir", Value = "Nevsehir" },
                new SelectListItem { Text = "Niğde", Value = "Nigde" },
                new SelectListItem { Text = "Ordu", Value = "Ordu" },
                new SelectListItem { Text = "Osmaniye", Value = "Osmaniye" },
                new SelectListItem { Text = "Rize", Value = "Rize" },
                new SelectListItem { Text = "Sakarya", Value = "Sakarya" },
                new SelectListItem { Text = "Samsun", Value = "Samsun" },
                new SelectListItem { Text = "Siirt", Value = "Siirt" },
                new SelectListItem { Text = "Sinop", Value = "Sinop" },
                new SelectListItem { Text = "Sivas", Value = "Sivas" },
                new SelectListItem { Text = "Şanlıurfa", Value = "Şanliurfa" },
                new SelectListItem { Text = "Şırnak", Value = "Şırnak" },
                new SelectListItem { Text = "Tekirdağ", Value = "Tekirdağ" },
                new SelectListItem { Text = "Tokat", Value = "Tokat" },
                new SelectListItem { Text = "Trabzon", Value = "Trabzon" },
                new SelectListItem { Text = "Tunceli", Value = "Tunceli" },
                new SelectListItem { Text = "Uşak", Value = "Uşak" },
                new SelectListItem { Text = "Van", Value = "Van" },
                new SelectListItem { Text = "Yalova", Value = "Yalova" },
                new SelectListItem { Text = "Yozgat", Value = "Yozgat" },
                new SelectListItem { Text = "Zonguldak", Value = "Zonguldak" }
            };
            ViewBag.Cities = cities;
            return View();

        }


        [HttpPost]
        public IActionResult Index(AddUserImage p)
        {
            UserValidator uv = new UserValidator();
            ValidationResult results = uv.Validate(p.User);


            if (results.IsValid)
            {
                if (p.UserImage != null)
                {
                    var extension = Path.GetExtension(p.UserImage.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Tema/assets/img/user-img", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    p.UserImage.CopyTo(stream);
                    p.User.UserImage = Path.Combine("/Tema/assets/img/user-img", newImageName);

                }
                p.User.UserStatus = true;
                um.TAdd(p.User);
                return RedirectToAction("Index", "About");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}
