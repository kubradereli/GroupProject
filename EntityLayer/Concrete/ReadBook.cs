using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
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
    }
}
