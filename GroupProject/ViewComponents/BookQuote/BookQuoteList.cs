using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.BookQuote
{
    public class BookQuoteList: ViewComponent
    {
        BookQuoteManager bookQuoteManager = new BookQuoteManager(new EfBookQuoteRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = bookQuoteManager.GetBookQuoteListWithUser().Where(s => s.BookID == id && s.BookQuoteStatus == true);
            return View(values);
        }
    }
}
