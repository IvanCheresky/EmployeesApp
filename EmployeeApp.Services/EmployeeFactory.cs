using System;
using AutoMapper;
using EmployeeApp.Data;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Enums;
using EmployeeApp.Services.Interfaces;

namespace EmployeeApp.Services
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private readonly IMapper _mapper;

        public EmployeeFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public EmployeeDTO GetEmployeeDTO(Employee employee)
        {
            switch (employee.ContractTypeName)
            {
                case ContractType.HourlySalaryEmployee:
                    var hourlyDTO = _mapper.Map<HourlyEmployeeDTO>(employee);
                    hourlyDTO.AnnualSalary = HourlyToAnnual(employee.HourlySalary);
                    return hourlyDTO;

                case ContractType.MonthlySalaryEmployee:
                    var monthlyDTO = _mapper.Map<MonthlyEmployeeDTO>(employee);
                    monthlyDTO.AnnualSalary = MonthlyToAnnual(employee.MonthlySalary);
                    return monthlyDTO;

                default:
                    throw new NotSupportedException();
            }
        }

        private decimal HourlyToAnnual(decimal hourlyPay)
        {
            return 120 * hourlyPay * 12;
        }

        private decimal MonthlyToAnnual(decimal monthlyPay)
        {
            return monthlyPay * 12;
        }
    }
}