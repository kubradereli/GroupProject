using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProject.Models
{
    public class AddUserImage
    {
        public User User { get; set; }
        public IFormFile UserImage { get; set; } 
    }
}
