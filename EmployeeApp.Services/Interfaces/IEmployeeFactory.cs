using EmployeeApp.Data;
using EmployeeApp.Data.DTOs;

namespace EmployeeApp.Services.Interfaces
{
    public interface IEmployeeFactory
    {
        EmployeeDTO GetEmployeeDTO(Employee employee);
    }
}