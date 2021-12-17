using EmployeeApp.Data.Enums;

namespace EmployeeApp.Data.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContractType ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal AnnualSalary { get; set; }
    }
}