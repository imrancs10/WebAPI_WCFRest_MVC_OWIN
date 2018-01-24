using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using System.Net;
using Moq;
using EmployeeApi.Controllers;
using EmployeeService;

namespace EmployeeApi.Tests
{
    [TestClass]
    public class EmployeeTest
    {
        FakeEmployeeService repo = new FakeEmployeeService();
        [TestMethod]
        public void Employee_GetAllEmployeeDetails_Should_Return_All_Employees_Details()
        {
            var controller = new EmployeeController();
            var result = controller.GetAllEmployeeDetails();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Employee_GetAllEmployeeDetails_Should_Return_NotFound_When_Result_Is_Empty()
        {
            //var mockData = new List<Employees>();
            //var moq = new Mock<IRepository>();
            //moq.Setup(x => x.GetAllEmployee()).Returns(mockData);
            var controller = new EmployeeController();
            var result = controller.GetAllEmployeeDetails();

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Employee_GetEmployeeById_Should_Return_Employee_Data()
        {
            var controller = new EmployeeController();
            var result = controller.GetEmployeeById(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Employee_GetEmployeeById_Should_Return_NotFound_When_Result_Is_Empty()
        {
            //var mockData = new EmployeeDataContract();
            //mockData = null;
            //var moq = new Mock<IEmployeeService>();
            //moq.Setup(x => x.GetEmployeeByID(2.ToString())).Returns(mockData);
            var controller = new EmployeeController();// (moq.Object);
            var result = controller.GetEmployeeById(2);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Employee_CheckUserCredential_Should_Return_NotFoundException_If_UserCredtialsExistsInDatabase()
        {
            var mockData = new UserDetail();
            mockData = null;
            var moq = new Mock<IEmployeeService>();
            moq.Setup(x => x.CheckUserCredetial(It.IsAny<string>(), It.IsAny<string>())).Returns(mockData);
            var controller = new EmployeeController();// (moq.Object);
            var result = controller.CheckUserCredential(string.Empty, string.Empty);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Employee_CheckUserCredential_Should_Return_OkResult_If_UserCredtialsExistsInDatabase()
        {
            var mockData = new UserDetail()
            {
                Username = "imran",
                Password = "12345"
            };
            var moq = new Mock<IRepository>();
            moq.Setup(x => x.CheckUserCredetial(It.IsAny<string>(), It.IsAny<string>())).Returns(mockData);

            var controller = new EmployeeController();// (moq.Object);
            var result = controller.CheckUserCredential("imran", "12345");
            Assert.IsNotNull(result);
        }
    }
}
