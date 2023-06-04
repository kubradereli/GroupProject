using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BookQuote
    {
        [Key]
        public int BookQuoteID { get; set; }
        public string BookQuoteContent { get; set; }
        public DateTime BookQuoteDate { get; set; }
        public bool BookQuoteStatus { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
