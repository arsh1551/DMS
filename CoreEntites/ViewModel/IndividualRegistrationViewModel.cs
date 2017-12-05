using CoreEntites.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
//using System.Web;
using System.Web.Mvc;

namespace DMS.Areas.IndividualsArea.Models
{
    public class IndividualRegistrationViewModel
    {
        public long? IndividualRecordId { get; set; }
        [Required]
        public string Prefix { get; set; }
        [Required(ErrorMessage = " ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = " ")]
        public string BirthDate { get; set; }
        [Required(ErrorMessage = " ")]
        //[MinLength(9, ErrorMessage = "Mininum lenght should be 9")]
        //[MaxLength(9, ErrorMessage = "Maximum lenght should be 9")]
        public string SSN { get; set; }   //Social Security Number
        [Required(ErrorMessage = " ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = " ")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = " ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " ")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = " ")]
        public string Suffix { get; set; }
        [Required(ErrorMessage = " ")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = " ")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? IsIndividualClient { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public List<SelectListItem> lstPrefix { get; set; }
        public string FirmName { get; set; }
    }
}