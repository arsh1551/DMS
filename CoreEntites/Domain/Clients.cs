using CoreEntites.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.SubDomain
{
    public class Clients : BaseEntity
    {
        [Key]
        public long ClientId { get; set; }
        public int AccountingFirmId { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }  
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Password { get; set; }
        public int ClientType { get; set; }
        public DateTime BirthDate { get; set; }
        public string SSN { get; set; }       //Social Security Number
        
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
