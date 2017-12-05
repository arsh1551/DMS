using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoreEntites.SessionManagement
{
  public  class SessionManagement
    {
        

        public class LoggedUserDetail
        {
            public long FirmId { get; set; }
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
        }
        public static LoggedUserDetail LoggedInUser
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                if (HttpContext.Current.Session["LoggedInUser"] == null)
                {
                    HttpContext.Current.Session["LoggedInUser"] = new LoggedUserDetail();
                }
                return (LoggedUserDetail)HttpContext.Current.Session["LoggedInUser"];
            }
            set
            {
                HttpContext.Current.Session["LoggedInUser"] = value;
            }
        }
    }
}
