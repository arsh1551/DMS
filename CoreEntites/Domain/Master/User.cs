namespace CoreEntites.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public long UserId { get; set; }

        

        public long? IndividualRecordId { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
        public long? FirmID { get; set; }
        public virtual Individual Individual { get; set; }
        public virtual Firm Firm { get; set; }
        //public long FirmId { get; set; }
    }
}
