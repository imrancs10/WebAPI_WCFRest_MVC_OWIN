using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeApi.Models
{
    public class UserDetail
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
      
        public int RoleId { get; set; }

        public UserRole UserRole { get; set; }
    }
}