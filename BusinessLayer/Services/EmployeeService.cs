using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<EmployeeInfo>> GetAllAsync()
        {
            _logger.LogInformation("Employee GetAllAsync service");
            return _mapper.Map<IEnumerable<EmployeeInfo>>(await _employeeRepository.GetAllAsync());
        }

        public async Task<EmployeeInfo> GetEmployeeByCodeAsync(string employeeCode)
        {
            _logger.LogInformation("Employee GetEmployeeByCodeAsync service");
            return _mapper.Map<EmployeeInfo>(await _employeeRepository.GetByCodeAsync(employeeCode));
        }

        public async Task<bool> CreateEmployeeAsync(EmployeeInfo employee)
        {
            _logger.LogInformation("Employee CreateEmployeeAsync service");
            return await _employeeRepository.SaveEmployeeAsync(_mapper.Map<Employee>(employee));
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeInfo employee)
        {
            _logger.LogInformation("Employee UpdateEmployeeAsync service");
            return await _employeeRepository.SaveEmployeeAsync(_mapper.Map<Employee>(employee));
        }

        public async Task<bool> DeleteEmployeeAsync(string employeeCode)
        {
            _logger.LogInformation("Employee DeleteEmployeeAsync service");
            return await _employeeRepository.DeleteEmployeeAsync(employeeCode);
        }
    }
}