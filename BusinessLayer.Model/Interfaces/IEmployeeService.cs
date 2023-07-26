using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeInfo>> GetAllAsync();
        Task<EmployeeInfo> GetEmployeeByCodeAsync(string employeeCode);
        Task<bool> CreateEmployeeAsync(EmployeeInfo employee);
        Task<bool> UpdateEmployeeAsync(EmployeeInfo employee);
        Task<bool> DeleteEmployeeAsync(string employeeCode);
    }
}