using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FamousQuote
    {
        [Key]
        public int FamousQuoteID { get; set; }
        public string Content { get; set; }
        public string Writer { get; set; }
        public string Career { get; set; }
    }
}
