using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeService
{
    public class EmployeeRepository : IRepository, IDisposable
    {
        EmpContext context = new EmpContext();
        public List<EmployeeDataContract> GetAllEmployee()
        {
            var employees = new List<Employees>();
            employees = context.Employees.ToList();
            var employeesContract = new List<EmployeeDataContract>();
            EmployeeDataContract empContract;
            foreach (var emp in employees)
            {
                empContract = new EmployeeDataContract()
                {
                    FirstName = emp.FirstName,
                    Gender = emp.Gender,
                    Id = emp.Id,
                    LastName = emp.LastName,
                    Salary = emp.Salary
                };
                employeesContract.Add(empContract);
            }
            return employeesContract;
        }

        public EmployeeDataContract GetEmployeeById(int id)
        {
            var data = context.Employees.Where(e => e.Id == id).SingleOrDefault();
            var emp = new EmployeeDataContract()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Gender = data.Gender,
                Salary = data.Salary,
                Id = data.Id
            };
            return emp;
        }

        public void AddEmployee(EmployeeDataContract empContract)
        {
            Employees emp = new Employees()
            {
                FirstName = empContract.FirstName,
                Gender = empContract.Gender,
                Id = empContract.Id,
                LastName = empContract.LastName,
                Salary = empContract.Salary
            };

            context.Employees.Add(emp);
            context.SaveChanges();
        }

        public UserDetail CheckUserCredetial(string userName, string password)
        {
            var data = context.UserDetails.Where(e => e.Username == userName && e.Password == password);

            return data.FirstOrDefault();
        }

        public void DeleteEmployee(int id)
        {
            var data = context.Employees.Where(e => e.Id == id).FirstOrDefault();

            if (data != null)
            {
                context.Employees.Remove(data);
                context.SaveChanges();
            }
        }

        public void UpdateEmployee(EmployeeDataContract empContract)
        {
            var data = context.Employees.Where(e => e.Id == empContract.Id).FirstOrDefault();
            data.FirstName = empContract.FirstName;
            data.Gender = empContract.Gender;
            data.LastName = empContract.LastName;
            data.Salary = empContract.Salary;
            context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}