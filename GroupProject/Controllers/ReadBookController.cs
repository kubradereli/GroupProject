﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Enums;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroupProject.Controllers
{
    public class ReadBookController : Controller
    {
        ReadBookManager readBookManager = new ReadBookManager(new EfReadBookRepository());

        public IActionResult BooksIRead()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            var values = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == BookReadStatusEnum.Okundu && s.UserID==userID).OrderBy(x => x.ReadingDate);
            return View(values);
        }

        public IActionResult BooksIWillRead()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            var values = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == BookReadStatusEnum.Okunacak && s.UserID == userID);
            return View(values);
        }

        public IActionResult BooksIWantToBuy()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();

            var values = readBookManager.GetReadBookListWithBook().Where(s => s.BookReadStatus == BookReadStatusEnum.SatınAlınacak && s.UserID == userID);
            return View(values);
        }

        [HttpGet]
        public IActionResult BookAdd()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in categoryManager.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }

        [HttpPost]
        public IActionResult BookAdd(ReadBook p)
        {
            BookAddValidator bv = new BookAddValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                Context c = new Context();
                var userMail = User.Identity.Name;
                p.UserID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
                p.BookReadStatus = BookReadStatusEnum.Okundu;
                p.Book.BookStatus = true;
                //p.ReadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                readBookManager.TAdd(p);
                return RedirectToAction("BooksIRead", "ReadBook");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    BookAdd();
                }
            }
            return View();
            
        }

    }
}