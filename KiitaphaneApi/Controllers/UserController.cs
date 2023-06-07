using KiitaphaneApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KiitaphaneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult UserList()
        {
            using var c = new Context();
            var values = c.Users.ToList();
            return Ok(values);
        }

        //[HttpPost]
        //public IActionResult UserAdd(User user)
        //{
        //    using var c = new Context();
        //    c.Add(user);
        //    c.SaveChanges();
        //    return Ok();
        //}

        [HttpGet("{id}")]
        public IActionResult UserGet(int id)
        {
            using var c = new Context();
            var user = c.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult UserDelete(int id)
        {
            using var c = new Context();
            var user = c.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(user);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UserUpdate(User user)
        {
            using var c = new Context();
            var u = c.Find<User>(user.UserID);
            if (u == null)
            {
                return NotFound();
            }
            else
            {
                u.UserName = user.UserName;
                u.UserSurname = user.UserSurname;
                u.UserAbout = user.UserAbout;
                u.UserDateOfBirth = user.UserDateOfBirth;
                u.UserCity = user.UserCity;
                u.UserImage = user.UserImage;
                //u.UserMail = user.UserMail;
                //u.UserPassword = user.UserPassword;
                c.Update(u);
                c.SaveChanges();
                return Ok();
            }
        }

        //[HttpPut]
        //public IActionResult UserChangePassword(User user)
        //{
        //    using var c = new Context();
        //    var u = c.Find<User>(user.UserID);
        //    if (u == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        u.UserPassword = user.UserPassword;
        //        c.Update(u);
        //        c.SaveChanges();
        //        return Ok();
        //    }
        //}
        
    }
}
