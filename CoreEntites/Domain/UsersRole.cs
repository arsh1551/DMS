using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.SubDomain
{
    public class UsersRole
    {
        [Key]
        public long RecordId { get; set; }
        public long IndividualClientRecordId { get; set; }
        public int RoleId { get; set; }
    }
}
