using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoreEntites.ViewModel
{
    public class ClientViewModel
    {

        public long ClientId { get; set; }
        
        public long AccountingFirmId { get; set; }
       
        public string ClientName { get; set; }

        public string ClientAddress { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        //[Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessage = "Email is not valid")]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public int ClientType { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string SSN { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
   

    }
}
