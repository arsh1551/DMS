namespace CoreEntites.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConnectionString")]
    public partial class ConnectionString : BaseEntity
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string DBName { get; set; }

        [StringLength(100)]
        public string ServerName { get; set; }

        [StringLength(50)]
        public string ServerUserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int? PlanId { get; set; }

        public long? FirmID { get; set; }

        [StringLength(50)]
        public string SubDomainName { get; set; }

        public virtual Firm Firm { get; set; }
    }
}
