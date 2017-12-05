﻿using CoreEntites.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.SubDomain
{
    public class Roles : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        
    }
}
