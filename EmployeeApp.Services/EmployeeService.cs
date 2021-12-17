using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Interfaces;
using EmployeeApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeFactory employeeFactory)
        {
            _employeeRepository = employeeRepository;
            _employeeFactory = employeeFactory;
        }

        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            var employee = await _employeeRepository.Get(id);

            if (employee == null)
            {
                throw new Exception("An employee with this id does not exist");
            }

            var employeeDto = _employeeFactory.GetEmployeeDTO(employee);

            return employeeDto;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAll();

            var employeesDto = employees.Select(e => _employeeFactory.GetEmployeeDTO(e)).ToList();

            return employeesDto;
        }

        public async Task<List<EmployeeDTO>> GetAllHourlyEmployees()
        {
            var employees = await _employeeRepository.GetAllHourly();

            var employeesDto = employees.Select(e => _employeeFactory.GetEmployeeDTO(e)).ToList();

            return employeesDto;
        }

        public async Task<List<EmployeeDTO>> GetAllMonthlyEmployees()
        {
            var employees = await _employeeRepository.GetAllMonthly();

            var employeesDto = employees.Select(e => _employeeFactory.GetEmployeeDTO(e)).ToList();

            return employeesDto;
        }
    }
}