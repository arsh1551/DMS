using CoreEntites.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.SubDomain
{
    public class IndividualClient : BaseEntity
    {
        [Key]
        public long IndividualClientRecordId { get; set; }
        public long? IndividualRecordId { get; set; }
        public long ClientRecordId { get; set; }
        public long? EmployeeId { get; set; }
        public bool IsIndividualClient { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
