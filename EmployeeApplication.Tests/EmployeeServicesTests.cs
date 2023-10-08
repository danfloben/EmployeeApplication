using Xunit;
using EmployeeApplication.Business;
using System.Threading.Tasks;
using EmployeeApplication.Business.Entities;
using EmployeeApplication.Business.Interface;
using System.Collections.Generic;

namespace EmployeeApplication.Tests
{
    public class EmployeeServicesTests
    {
        [Fact]
        public async Task GetEmployeeById_ValidId_ReturnsEmployee()
        {
            EmployeeServices employeeServices = new EmployeeServices();

            var result = await employeeServices.GetEmployeeById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetEmployees_ReturnsListOfEmployees()
        {
            EmployeeServices employeeServices = new EmployeeServices();

            var result = await employeeServices.GetEmployees();

            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
