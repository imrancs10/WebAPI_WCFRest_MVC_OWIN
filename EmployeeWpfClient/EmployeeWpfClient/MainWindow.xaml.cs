using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeWpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Load()
        {
            


        }

        private void btnGetEmp_Click(object sender, RoutedEventArgs e)
        {
            EmployeeServiceReference.EmployeeServiceClient client =
                new EmployeeServiceReference.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            EmployeeServiceReference.Employee emp = client.GetEmployee(1);
            txtEmpId.Text = emp.Id.ToString();
            txtEmpName.Text = emp.Name;
            txtEmpDept.Text = emp.Department;
            txtEmpSalary.Text = emp.Salary.ToString();
        }

        private void btnSaveEmp_Click(object sender, RoutedEventArgs e)
        {
            EmployeeServiceReference.Employee emp = new EmployeeServiceReference.Employee();
            emp.Id = Convert.ToInt32( txtEmpId.Text);
            emp.Name = txtEmpName.Text;
            emp.Department = txtEmpDept.Text;
            emp.Salary = Convert.ToDouble(txtEmpSalary.Text);
            EmployeeServiceReference.EmployeeServiceClient client =
               new EmployeeServiceReference.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            client.SaveEmployee(emp);
            
        }
    }
}
