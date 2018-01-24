using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Tests
{
    public class EmployeeFakeRepository : IRepository
    {
        List<EmployeeDataContract> empList = new List<EmployeeDataContract>()
                             {
                               new EmployeeDataContract
                               {
                                  Id = 1,
                                  FirstName ="Deo",
                                  LastName = "Nandan",
                                  Gender = "M",
                                  Salary = 15000
                               },
                               new EmployeeDataContract
                               {
                                  Id = 3,
                                  FirstName ="Imran",
                                  LastName = "Sheikh",
                                  Gender = "M",
                                  Salary = 15000
                               }
                             };
        public void AddEmployee(EmployeeDataContract emp)
        {
            if (emp.Id == 5)
            {
                throw new Exception();
            }

            if (emp != null)
            {
                empList.Add(emp);
            }                       
        }

        public UserDetail CheckUserCredetial(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            var data = empList.Where(e => e.Id == id).Single();
            if (data != null)
            {
                empList.Remove(data);
            }
            else
                throw new KeyNotFoundException();
        }

        public List<EmployeeDataContract> GetAllEmployee()
        {           
            return empList;
        }

        public EmployeeDataContract GetEmployeeById(int id)
        {         
            var data = empList.Where(x => x.Id == id).SingleOrDefault();
            return data;
        }

        public void UpdateEmployee(EmployeeDataContract empContract)
        {
            if(empContract != null)
            {
                var emp = empList.Where(e => e.Id == empContract.Id).SingleOrDefault();
                if(emp == null)
                {
                    throw new KeyNotFoundException(); ;
                }
                empList.Remove(emp);
                empList.Add(empContract);
            }
            
        }
    }
}
