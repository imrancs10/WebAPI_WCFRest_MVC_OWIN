using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeService
{
    public class UserDetail
    {
        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
      
        [ForeignKey("UserRole")]
        public int RoleId { get; set; }

        public UserRole UserRole { get; set; }
    }
}