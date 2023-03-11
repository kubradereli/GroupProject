using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KiitaphaneApi.DataAccessLayer
{
    public class ReadBook
    {
        [Key]
        public int ReadBookID { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime ReadingDate { get; set; }
        public int ReadBookReviewPoint { get; set; }
        public int BookReadStatus { get; set; }
        // 1 okundu
        // 2 okunacak
        // 3 satın alınacak
    }
}
