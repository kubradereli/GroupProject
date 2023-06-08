using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.ViewComponents.Comment
{
    public class CommentList: ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.GetCommentListWithUser().Where(s=>s.ReadingActivityID == id && s.CommentStatus == true);
            return View(values);
        }
    }
}
