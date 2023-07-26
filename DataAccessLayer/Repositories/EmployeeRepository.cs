using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbWrapper<Employee> _employeeDbWrapper;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper, ILogger<EmployeeRepository> logger)
        {
            _employeeDbWrapper = employeeDbWrapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Getting all employees");
                return await _employeeDbWrapper.FindAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all employees");
                return null;
            }
        }

        public async Task<Employee> GetByCodeAsync(string employeeCode)
        {
            try
            {
                _logger.LogInformation($"Getting an employee by code: {employeeCode}");
                return (await _employeeDbWrapper.FindAsync(t => t.EmployeeCode.Equals(employeeCode)).ConfigureAwait(false))?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting an employee by code: {employeeCode}");
                return null;
            }
        }

        public async Task<bool> SaveEmployeeAsync(Employee employee)
        {
            try
            {
                var itemRepo = (await _employeeDbWrapper.FindAsync(t =>
                t.EmployeeCode.Equals(employee.EmployeeCode)).ConfigureAwait(false))?.FirstOrDefault();

                if (itemRepo != null)
                {
                    itemRepo.EmployeeName = employee.EmployeeName;
                    itemRepo.Occupation = employee.Occupation;
                    itemRepo.EmployeeStatus = employee.EmployeeStatus;
                    itemRepo.EmailAddress = employee.EmailAddress;
                    itemRepo.Phone = employee.Phone;
                    itemRepo.LastModified = employee.LastModified;

                    _logger.LogInformation($"Updating an employee by code: {employee.EmployeeCode}");
                    return await _employeeDbWrapper.UpdateAsync(itemRepo);
                }

                _logger.LogInformation("Creating an employee");
                return await _employeeDbWrapper.InsertAsync(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving an employee");
                return false;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(string employeeCode)
        {
            try
            {
                _logger.LogInformation($"Deleting n employee by code: {employeeCode}");
                return await _employeeDbWrapper.DeleteAsync(e => e.EmployeeCode.Equals(employeeCode));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting an employee");
                return false;
            }
        }
    }
}