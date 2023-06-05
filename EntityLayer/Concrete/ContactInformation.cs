using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContactInformation
    {
        [Key]
        public int ContactInformationID { get; set; }
        public string Image { get; set; }
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Location { get; set; }

        public object TGetList()
        {
            throw new NotImplementedException();
        }
    }
}
