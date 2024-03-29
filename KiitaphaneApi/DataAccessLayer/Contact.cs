﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KiitaphaneApi.DataAccessLayer
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string ContactMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
        public bool ContactStatus { get; set; }
    }
}
