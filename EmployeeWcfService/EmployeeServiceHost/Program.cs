using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using EmployeeWcfService;
namespace EmployeeServiceHost
{
    class Program
    {
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(EmployeeService)))
            {
                host.Open();
                Console.WriteLine("Employee Wcf Service started at " + DateTime.Now.ToString());
                Console.ReadLine(); //
            }
        }
    }
}
