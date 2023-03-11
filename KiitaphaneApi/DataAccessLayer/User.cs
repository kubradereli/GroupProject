using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KiitaphaneApi.DataAccessLayer
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime UserDateOfBirth { get; set; }
        public string UserCity { get; set; }
        public string UserAbout { get; set; }
        public string UserImage { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public bool UserStatus { get; set; }
        public List<ReadBook> ReadBooks { get; set; }
        public List<UserReadingActivity> UserReadingActivities { get; set; }
    }
}
