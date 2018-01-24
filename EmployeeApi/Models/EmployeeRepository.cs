using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApi.Models
{
    public class EmployeeRepository : IRepository, IDisposable
    {
        EmpContext context = new EmpContext();
        public List<Employees> GetAllEmployee()
        {
            var employees = new List<Employees>();
            employees = context.Employees.ToList();
            return employees;
        }

        public Employees GetEmployeeById(int id)
        {
            var data = context.Employees.Where(e => e.Id == id);

            return data.SingleOrDefault();
        }

        public void AddEmployee(Employees emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
        }

        public UserDetail CheckUserCredetial(string userName, string password)
        {
            var data = context.UserDetails.Where(e => e.Username == userName && e.Password == password);

            return data.FirstOrDefault();
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