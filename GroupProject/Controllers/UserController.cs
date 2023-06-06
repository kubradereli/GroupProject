using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new EfUserRepository());

        
        public IActionResult Index()
        {
            return View();
        }

        // apilerle çalışılıyorsa async ifadesi kullanılır.
        [HttpGet]
        public async Task<IActionResult> UserInformation()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44307/api/User/" + userID);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<User>(jsonString);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UserInformation(User user)
        {
            var httpClient = new HttpClient();
            var jsonUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44307/api/User", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User");
            }
            return View(user);
        }
        public IActionResult UserStatusList(string sort)
        {
            var values = userManager.TGetList();
            switch (sort)
            {
                case "UserASC":
                    values = values.OrderBy(r => r.UserName).ToList();
                    break;
                case "UserDESC":
                    values = values.OrderByDescending(r => r.UserName).ToList();
                    break;
                default:
                    values = values.OrderBy(r => r.UserName).ToList();
                    break;
            }
            return View(values);
        }
    
        public IActionResult UserStatusChange(int id)
        {

            var value = userManager.TGetById(id);
            if (value.UserStatus == true)
            {
                value.UserStatus = false;

            }
            else
            {
                value.UserStatus = true;
            }
            userManager.TUpdate(value);

            return RedirectToAction("UserStatusList");
        }
    }
}
