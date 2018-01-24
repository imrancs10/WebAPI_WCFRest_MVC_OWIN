using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeService;
namespace EmployeeApi.Tests
{
    public class FakeEmployeeService : IEmployeeService
    {
        public bool AddEmployee(EmployeeDataContract employee)
        {
            throw new NotImplementedException();
        }

        public UserDetail CheckUserCredetial(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeDataContract> GetAllEmployee()
        {
            var data = new List<EmployeeDataContract>()
            {
               new EmployeeDataContract
               {
                   Id = 1,
                   FirstName = "Deo",
                   LastName = "P",
                   Gender = "M",
                   Salary = 1500
               }
            };
            return data;
        }

        public EmployeeDataContract GetEmployeeByID(string employeeID)
        {
            var data = GetAllEmployee().Where(e => e.Id == int.Parse(employeeID)).FirstOrDefault();

            return data;
        }

        public bool UpdateEmmployee(EmployeeDataContract employee)
        {
            throw new NotImplementedException();
        }
    }
}
