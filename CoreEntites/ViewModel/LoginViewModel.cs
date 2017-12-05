using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = " ")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }
}
