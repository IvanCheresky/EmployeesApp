using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApp.Data;
using EmployeeApp.Data.DTOs;

namespace EmployeeApp.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetEmployee(int id);
        Task<List<EmployeeDTO>> GetAllEmployees();
        Task<List<EmployeeDTO>> GetAllHourlyEmployees();
        Task<List<EmployeeDTO>> GetAllMonthlyEmployees();
    }
}