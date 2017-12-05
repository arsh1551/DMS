using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.ViewModel
{
    public class ForgetPasswordViewModel
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string tempUserId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string Domain { get; set; }
    }
}
