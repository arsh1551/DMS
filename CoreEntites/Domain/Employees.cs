using CoreEntites.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoreEntites.SubDomain
{
    public class Employees : BaseEntity
    {
        [Key]
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
 
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }


    }
}
