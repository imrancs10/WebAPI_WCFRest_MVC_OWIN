using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeService
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }

        public string Role { get; set; }
    }
}