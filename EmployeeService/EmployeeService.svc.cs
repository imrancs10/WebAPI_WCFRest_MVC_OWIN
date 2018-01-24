using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository repository;
        public EmployeeService(IRepository repo)
        {
            this.repository = repo;
        }

        public bool AddEmployee(EmployeeDataContract employee)
        {
            try
            {
                repository.AddEmployee(employee);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new FaultException(ex.Message);
            }

        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                repository.DeleteEmployee(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new FaultException(ex.Message);
            }
        }

        public List<EmployeeDataContract> GetAllEmployee()
        {
            var result = repository.GetAllEmployee();

            return result.ToList();
        }

        public EmployeeDataContract GetEmployeeByID(string employeeID)
        {
            var result = repository.GetEmployeeById(Convert.ToInt32(employeeID));
            return result;
        }

        public bool UpdateEmmployee(EmployeeDataContract employee)
        {
            try
            {
                repository.UpdateEmployee(employee);
                return true;
            }
            catch(Exception ex)
            {
                return false;
                throw new FaultException(ex.Message);
            }
        }

        public UserDetail CheckUserCredetial(string userName, string password)
        {
            var result = repository.CheckUserCredetial(userName, password);
            return result;
        }

    }
}
