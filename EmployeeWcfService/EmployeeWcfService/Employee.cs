using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace EmployeeWcfService
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Department { get; set; }
        [DataMember]
        public Double Salary { get; set; }

        public Employee()
        {

        }
        public Employee(int id,string name,string department,double salary)
        {
            this.Id = id;
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }
    }
}
