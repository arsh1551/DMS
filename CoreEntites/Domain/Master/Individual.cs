namespace CoreEntites.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 
        Individual
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Individual()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public long IndividualRecordId { get; set; }

        [StringLength(50)]
        public string Prefix { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(250)]
        public string SSN { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string Suffix { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        public long? CreatedBy { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public long? ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
