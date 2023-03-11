using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KiitaphaneApi.DataAccessLayer
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int BookPageCount { get; set; }
        public string BookPublishingHouse { get; set; }
        public string BookCoverImage { get; set; }
        public string BookBackCoverImage { get; set; }
        public bool BookStatus { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ReadBook> ReadBooks { get; set; }
        public List<ReadingActivity> ReadingActivities { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
