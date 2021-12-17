using AutoMapper;
using EmployeeApp.Data;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Enums;
using EmployeeApp.Services;
using Moq;
using NUnit.Framework;

namespace EmployeeApp.Tests
{
    public class EmployeeFactoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetEmployeeDTO_HourlySalaryOf100_ReturnsCorrectAnnual()
        {
            //arrange
            var employee = new Employee()
            {
                ContractTypeName = ContractType.HourlySalaryEmployee,
                HourlySalary = 100
            };

            var employeeDto = new HourlyEmployeeDTO();

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<HourlyEmployeeDTO>(It.IsAny<Employee>())).Returns(employeeDto);
            var factory = new EmployeeFactory(mockMapper.Object);

            //act
            var annualSalary = factory.GetEmployeeDTO(employee).AnnualSalary;

            //assert
            Assert.AreEqual(120 * 100 * 12, annualSalary);
        }

        [Test]
        public void GetEmployeeDTO_MonthlySalaryOf100_ReturnsCorrectAnnual()
        {
            //arrange
            var employee = new Employee()
            {
                ContractTypeName = ContractType.MonthlySalaryEmployee,
                MonthlySalary = 100
            };

            var employeeDto = new MonthlyEmployeeDTO();

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<MonthlyEmployeeDTO>(It.IsAny<Employee>())).Returns(employeeDto);
            var factory = new EmployeeFactory(mockMapper.Object);

            //act
            var annualSalary = factory.GetEmployeeDTO(employee).AnnualSalary;

            //assert
            Assert.AreEqual(100 * 12, annualSalary);
        }
    }
}