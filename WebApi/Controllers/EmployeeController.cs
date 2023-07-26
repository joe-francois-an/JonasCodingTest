using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET api/<controller>
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeDto>>(await _employeeService.GetAllAsync());
        }

        // GET api/<controller>/5
        public async Task<EmployeeDto> Get(string employeeCode)
        {
            return _mapper.Map<EmployeeDto>(await _employeeService.GetEmployeeByCodeAsync(employeeCode));
        }

        // POST api/<controller>
        public async Task<bool> Post([FromBody] EmployeeDto employee)
        {
            return await _employeeService.CreateEmployeeAsync(_mapper.Map<EmployeeInfo>(employee));
        }

        // PUT api/<controller>/5
        public async Task<bool> Put(string employeeCode, [FromBody] EmployeeDto employee)
        {
            return await _employeeService.UpdateEmployeeAsync(_mapper.Map<EmployeeInfo>(employee));
        }

        // DELETE api/<controller>/5
        public async Task<bool> Delete(string employeeCode)
        {
            return await _employeeService.DeleteEmployeeAsync(employeeCode);
        }
    }
}