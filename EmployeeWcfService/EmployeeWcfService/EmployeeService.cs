using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        public Employee GetEmployee(int employeeId)
        {
            Employee emp = new Employee(employeeId, "John", "Engg", 30000);
            Console.WriteLine("Existing Employee details fetched having following details:");
            Console.WriteLine(string.Format("Id:{0} , Name:{1},  Department:{2}, Salary:{3}", emp.Id, emp.Name, emp.Department, emp.Salary));
            return emp;
        }

        public void SaveEmployee(Employee employee)
        {
            Employee newEmp = new Employee();
            newEmp.Id = employee.Id;
            newEmp.Name = employee.Name;
            newEmp.Department = employee.Department;
            newEmp.Salary = employee.Salary;
            Console.WriteLine("New Employee Saved having following details:");
            Console.WriteLine(string.Format("Id:{0} , Name:{1},  Department:{2}, Salary:{3}", newEmp.Id, newEmp.Name, newEmp.Department, newEmp.Salary));
        }
    }
}
