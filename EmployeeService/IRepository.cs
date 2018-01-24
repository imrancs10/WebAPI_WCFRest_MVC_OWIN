using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public interface IRepository
    {
        List<EmployeeDataContract> GetAllEmployee();
        EmployeeDataContract GetEmployeeById(int id);

        void AddEmployee(EmployeeDataContract emp);

        UserDetail CheckUserCredetial(string userName, string password);
        void DeleteEmployee(int id);
        void UpdateEmployee(EmployeeDataContract empContract);
    }
}
