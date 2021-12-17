using EmployeeApp.Services.Clients;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Data.Enums;
using EmployeeApp.Data.Interfaces;

namespace EmployeeApp.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeClientService _employeeClientService;
        public EmployeeRepository(EmployeeClientService employeeClientService)
        {
            _employeeClientService = employeeClientService;
        }

        public async Task<Employee> Get(int id)
        {
            var employees = await _employeeClientService.GetAll();
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await _employeeClientService.GetAll();
            return employees;
        }

        public async Task<List<Employee>> GetAllHourly()
        {
            var employees = await _employeeClientService.GetAll();
            return employees.Where(e => e.ContractTypeName == ContractType.HourlySalaryEmployee).ToList();
        }

        public async Task<List<Employee>> GetAllMonthly()
        {
            var employees = await _employeeClientService.GetAll();
            return employees.Where(e => e.ContractTypeName == ContractType.MonthlySalaryEmployee).ToList();
        }
    }
}