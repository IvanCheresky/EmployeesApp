using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetEmployee(id);
            return Ok(employee);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("AllHourly")]
        public async Task<IActionResult> GetAllHourly()
        {
            var employees = await _employeeService.GetAllHourlyEmployees();
            return Ok(employees);
        }

        [HttpGet("AllMonthly")]
        public async Task<IActionResult> GetAllMonthly()
        {
            var employees = await _employeeService.GetAllMonthlyEmployees();
            return Ok(employees);
        }
    }
}
