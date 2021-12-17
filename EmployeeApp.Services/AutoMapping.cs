using AutoMapper;
using EmployeeApp.Data;
using EmployeeApp.Data.DTOs;

namespace EmployeeApp.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, HourlyEmployeeDTO>();
            CreateMap<Employee, MonthlyEmployeeDTO>();
        }
    }
}