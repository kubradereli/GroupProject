﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using GroupProject.MailService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class LoginController : Controller
    {
        // Login Sayfası
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(User p, bool rememberMe = false)
        {
            //var message = new Message(new string[] { "aleynaebrt@gmail.com" }, "Test email", "This is the content from our email.");
            //new EMailService().SendEmail(message);
            Context c = new Context();
            var datavalue = c.Users.FirstOrDefault(x => x.UserMail == p.UserMail && x.UserPassword == p.UserPassword);
            var datavalueAdmin = c.Admins.FirstOrDefault(x => x.AdminMail == p.UserMail && x.AdminPassword == p.UserPassword);
            if (datavalue != null || datavalueAdmin != null)
            {
                if (datavalue != null && datavalue.UserStatus == false)
                {
                    ViewBag.mesaj = "Girişiniz Engellendi !";
                    return View();
                }
                else
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.UserMail)
                };
                    var useridentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = rememberMe // Set the persistent flag based on the "rememberMe" parameter
                    };

                    await HttpContext.SignInAsync(principal, authProperties);
                    return RedirectToAction("Index", "About");
                }
            }
            else
            {
                ViewBag.mesaj = "Hatalı E-mail veya şifre.Lütfen tekrar deneyiniz.";

                return View();
            }
        }

        // Çıkış yap
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}