using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {
        CategoryManager categoryManager= new CategoryManager(new EfCategoryRepository());
        ReadingActivityManager activityManager = new ReadingActivityManager(new EfReadingActivityRepository());

        public IViewComponentResult Invoke()
        {
            var countsofCategories = activityManager.GetCountofCategoriesFromActivity();
            var values = categoryManager.TGetList();
            foreach (var category in values)
            {
                if (countsofCategories.FirstOrDefault(x => x.CategoryName == category.CategoryName) == null)
                {
                    countsofCategories.Add(new CategoryCount() 
                    {
                        CategoryName = category.CategoryName,
                        Count = 0
                    });
                }
            }

            countsofCategories = countsofCategories.OrderByDescending(x => x.Count).ToList();
            return View(countsofCategories);
        }
    }
}
