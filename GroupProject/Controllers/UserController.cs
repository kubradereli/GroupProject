using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
