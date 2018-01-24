using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeApi.Models
{
    public class UserRole
    {
        public int RoleId { get; set; }

        public string Role { get; set; }
    }
}