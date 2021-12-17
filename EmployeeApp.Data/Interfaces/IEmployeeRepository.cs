
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> Get(int id);
        Task<List<Employee>> GetAll();
        Task<List<Employee>> GetAllHourly();
        Task<List<Employee>> GetAllMonthly();
    }
}