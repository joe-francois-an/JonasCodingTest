using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeInfo>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EmployeeInfo>>(await _employeeRepository.GetAllAsync());
        }

        public async Task<EmployeeInfo> GetEmployeeByCodeAsync(string employeeCode)
        {
            return _mapper.Map<EmployeeInfo>(await _employeeRepository.GetByCodeAsync(employeeCode));
        }

        public async Task<bool> CreateEmployeeAsync(EmployeeInfo employee)
        {
            return await _employeeRepository.SaveEmployeeAsync(_mapper.Map<Employee>(employee));
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeInfo employee)
        {
            return await _employeeRepository.SaveEmployeeAsync(_mapper.Map<Employee>(employee));
        }

        public async Task<bool> DeleteEmployeeAsync(string employeeCode)
        {
            return await _employeeRepository.DeleteEmployeeAsync(employeeCode);
        }
    }
}