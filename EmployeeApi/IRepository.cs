using EmployeeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi
{
    public interface IRepository
    {
        List<Employees> GetAllEmployee();

        Employees GetEmployeeById(int id);

        void AddEmployee(Employees emp);

        UserDetail CheckUserCredetial(string userName, string password);
    }
}
