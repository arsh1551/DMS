
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.ViewModel
{
    public class EmployeesViewModel
    {
        [Required(ErrorMessage = "*")]
        public long ClientId { get; set; }
        public long EmployeeId { get; set; }
        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "*")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "*")]

        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        [Required(ErrorMessage = "*")]
        public string Title { get; set; }
        [Required(ErrorMessage ="*")]
        public string Address { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public List<ClientViewModel> Clients { get; set; }
    }
}
