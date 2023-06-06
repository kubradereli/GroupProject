using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class AddActivityImage
    {
        public ReadingActivity ReadingActivity { get; set; }
        public IFormFile ActivityImage { get; set; }
      
    }
}
