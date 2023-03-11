using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KiitaphaneApi.DataAccessLayer
{
    public class UserReadingActivity
    {
        [Key]
        public int UserReadingActivityID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int ActivityID { get; set; }
        public ReadingActivity ReadingActivity { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public int NumberOfPages { get; set; }
        public int BookReviewScore { get; set; }
    }
}
