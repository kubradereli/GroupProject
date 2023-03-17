using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KiitaphaneApi.DataAccessLayer
{
    public class ReadingActivity
    {
        [Key]
        public int ActivityID { get; set; }
        public string ActivityTitle { get; set; }
        public string ActivityContent { get; set; }
        public string ActivityImage { get; set; }
        public DateTime ActivityCreateDate { get; set; }
        public bool ActivityStatus { get; set; }
        public List<UserReadingActivity> UserReadingActivities { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int AdminID { get; set; }
        public User Admin { get; set; }
    }
}
