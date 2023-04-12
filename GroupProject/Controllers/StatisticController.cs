using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GroupProject.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly Context _database;

        public StatisticController(Context context)
        {
            _database = context;
        }

        [HttpGet]
        public Object OkunanKitapSayfalari(DataSourceLoadOptionsBase loadOptions)
        {
            return "";
           // string sql = $@"SELECT B.BookName,b.BookPageCount FROM ReadBooks RB
           //     LEFT OUTER JOIN Books B ON RB.BookID=B.BookID
           //     WHERE BookReadStatus=1 AND UserID=1";
           //// var values = _database.ReadBook_Page.FromSqlRaw(sql).ToList();
           // return DataSourceLoader.Load(values, loadOptions);
        }
    }
}
