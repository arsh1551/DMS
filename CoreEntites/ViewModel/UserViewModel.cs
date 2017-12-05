using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.ViewModel
{
    public class UserViewModel
    {
        public long UserId { get; set; }
        public long? IndividualRecordId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public bool? IsEmailConfirm { get; set; }
        public long? TempUserID { get; set; }
    }
}
