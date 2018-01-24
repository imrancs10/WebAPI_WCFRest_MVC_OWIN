using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace EmployeeService.Tests
{
    [TestClass]
    public class EmployeeServiceTest
    {
        EmployeeFakeRepository repo;
        EmployeeService service;

        [TestInitialize]
        public void TestSetup()
        {
            repo = new EmployeeFakeRepository();
            service = new EmployeeService(repo);
        }

        [TestMethod]
        public void Employeeservice_GetAllEmployee_Should_Return_AllEmployeeDetails()
        {
            var result = service.GetAllEmployee();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Employeeservice_GetEmployeeByID_Should_Return_EmployeeDetails()
        {
            var result = service.GetEmployeeByID("1");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Employeeservice_GetEmployeeByID_Should_Return_Null_When_NoResultFound()
        {
            var result = service.GetEmployeeByID("2");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Employeeservice_AddEmployee_Should_Return_True_When_EmployeeData_Is_Added()
        {
 
            var result = service.AddEmployee(GetEmployeedata());
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        public void Employeeservice_AddEmployee_Should_Return_False_When_EmployeeData_Is_Not_Added()
        {
            var emp = GetEmployeedata();
            emp.Id = 5;

            var result = service.AddEmployee(emp);
            Assert.AreEqual(result, false);

        }

        [TestMethod]
        public void Employeeservice_UpdateEmployee_Should_Return_True_When_EmployeeData_Is_Added()
        {

            var result = service.UpdateEmmployee(GetEmployeedata());
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        public void Employeeservice_UpdateEmployee_Should_Return_False_When_EmployeeData_Is_Added()
        {
            var emp = GetEmployeedata();
            emp.Id = 5;

            var result = service.UpdateEmmployee(emp);
            Assert.AreEqual(result, false);

        }

        [TestMethod]
        public void Employeeservice_CheckUserCredetial_Should_Return_UserDetail_When_UsernamePassword()
        {
            var mockData = new UserDetail()
            {
                Username = "imran",
                Password = "12345"
            };
            var moq = new Mock<IRepository>();
            moq.Setup(x => x.CheckUserCredetial(It.IsAny<string>(), It.IsAny<string>())).Returns(mockData);

            var service = new EmployeeService(moq.Object);
            var result = service.CheckUserCredetial("imran", "12345");
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Employeeservice_Delete_Should_Return_True_When_EmployeeData_Is_Deleted()
        {
            var result = service.DeleteEmployee(3);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Employeeservice_Delete_Should_Return_False_When_EmployeeData_NotFound()
        {
            
            var result = service.DeleteEmployee(4);
            Assert.AreEqual(result, false);
        }

        [TestCleanup]
        public void TestTearDown()
        {
            repo = null;
            service = null;
        }

        private EmployeeDataContract GetEmployeedata()
        {
            return new EmployeeDataContract
            {
               Id = 3,
               FirstName = "Sam",
               LastName = "Romera",
               Gender = "M",
               Salary = 20000
            };
        }
    }
}
