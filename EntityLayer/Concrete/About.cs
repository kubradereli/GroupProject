using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string AboutDetails1 { get; set; }
        public string AboutDetails2 { get; set; }
        public string AboutBackgroundImage { get; set; }
        public string AboutSmallImage1 { get; set; }
        public string AboutSmallImage2 { get; set; }
        public bool AboutStatus { get; set; }        
        public string CardTitle1 { get; set; }
        public string CardTitle2 { get; set; }
        public string CardTitle3 { get; set; }
        public string CardTitle4 { get; set; }
        public string CardDescription1 { get; set; }
        public string CardDescription2 { get; set; }
        public string CardDescription3 { get; set; }
        public string CardDescription4 { get; set; }
        public string MainTitle { get; set; }
    }
}
