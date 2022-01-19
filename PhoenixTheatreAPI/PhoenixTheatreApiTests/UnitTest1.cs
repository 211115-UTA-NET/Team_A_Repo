using Microsoft.EntityFrameworkCore;
using Moq;
using PhoenixTheatreAPI.Controllers;
using PhoenixTheatreAPI.Data;
using PhoenixTheatreAPI.Dtos;
using PhoenixTheatreAPI.Services;
using System;
using Xunit;

namespace PhoenixTheatreApiTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetCustomerByNameTest()
        {
            Guid customerId = Guid.NewGuid();
            string firstName = "SomeFirstName";
            string lastName = "SomeLastName";
            string userName = "username1";
            string password = "p@ssword!";

            Customer customer =
                new()
                {
                    CustomerId = customerId,
                    FirstName = firstName,
                    LastName = lastName,
                    Username = userName,
                    UserPassword = password
                };

            var mockSet = new Mock<DbSet<Customer>>();

            var mockContext = new Mock<PhoenixTheatreContext>();

            mockContext.Setup(x => x.Customer).Returns(mockSet.Object);

            var mockService = new Mock<PhoenixTheatreService>();

            mockService.Setup(x => x.GetCustomerByName(firstName, lastName)).Returns(customer);

            var controller = new PhoenixTheatreController(mockService.Object);

            var actual = controller.GetCustomerByName(firstName, lastName);

            Assert.Same(customer, actual.Value);
            Assert.Equal(customer.CustomerId, actual.Value?.CustomerId);
            Assert.Equal(customer.FirstName, actual.Value?.FirstName);
            Assert.Equal(customer.LastName, actual.Value?.LastName);
            Assert.Equal(customer.Username, actual.Value?.Username);
            Assert.Equal(customer.UserPassword, actual.Value?.UserPassword);
        }

        [Fact]
        public void GetEmployeeByNameTest()
        {
            Guid employeeId = Guid.NewGuid();
            string firstName = "SomeFirstName";
            string lastName = "SomeLastName";
            string userName = "username1";
            string password = "p@ssword!";
            string isManager = "yes";
            int theatreId = 1;

            Employee employee =
                new()
                {
                    EmployeeId = employeeId,
                    FirstName = firstName,
                    LastName = lastName,
                    Username = userName,
                    UserPassword = password,
                    IsManager = isManager,
                    TheatreId = theatreId
                };

            var mockSet = new Mock<DbSet<Employee>>();

            var mockContext = new Mock<PhoenixTheatreContext>();

            mockContext.Setup(x => x.Employee).Returns(mockSet.Object);

            var mockService = new Mock<PhoenixTheatreService>();

            mockService.Setup(x => x.GetEmployeeByName(firstName, lastName)).Returns(employee);

            var controller = new PhoenixTheatreController(mockService.Object);

            var actual = controller.GetEmployeeByName(firstName, lastName);

            Assert.Same(employee, actual.Value);
            Assert.Equal(employee.EmployeeId, actual.Value?.EmployeeId);
            Assert.Equal(employee.FirstName, actual.Value?.FirstName);
            Assert.Equal(employee.LastName, actual.Value?.LastName);
            Assert.Equal(employee.Username, actual.Value?.Username);
            Assert.Equal(employee.UserPassword, actual.Value?.UserPassword);
            Assert.Equal(employee.IsManager, actual.Value?.IsManager);
            Assert.Equal(employee.TheatreId, actual.Value?.TheatreId);
        }
    }
}