using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.QuotesAboutBooks
{
    public class FamousQuotes: ViewComponent
    {
        FamousQuoteManager famousQuoteManager = new FamousQuoteManager(new EfFamousQuoteRepository());
        public IViewComponentResult Invoke()
        {
            var values = famousQuoteManager.TGetList();
            return View(values);
        }
    }
}
