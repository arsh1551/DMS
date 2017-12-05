using CoreEntites.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.SubDomain
{
    public class Invitations : BaseEntity
    {
        [Key]
        public long InvitationRecordID { get; set; }
        public long ClientRecordID { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string SSN { get; set; }
        public string Phone { get; set; }
        public string Suffix { get; set; }
        public bool IsClient { get; set; }
        public bool HasAccepted { get; set; }
  
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
