using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET api/<controller>
        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            _logger.LogInformation("Employee GetAll endpoint");
            return _mapper.Map<IEnumerable<EmployeeDto>>(await _employeeService.GetAllAsync());
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("{employeeCode}")]
        public async Task<EmployeeDto> Get(string employeeCode)
        {
            _logger.LogInformation("Employee Get endpoint");
            return _mapper.Map<EmployeeDto>(await _employeeService.GetEmployeeByCodeAsync(employeeCode));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<bool> Post([FromBody] EmployeeDto employee)
        {
            _logger.LogInformation("Employee Post endpoint");
            return await _employeeService.CreateEmployeeAsync(_mapper.Map<EmployeeInfo>(employee));
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("{employeeCode}")]
        public async Task<bool> Put(string employeeCode, [FromBody] EmployeeDto employee)
        {
            _logger.LogInformation("Employee Put endpoint");
            return await _employeeService.UpdateEmployeeAsync(_mapper.Map<EmployeeInfo>(employee));
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{employeeCode}")]
        public async Task<bool> Delete(string employeeCode)
        {
            _logger.LogInformation("Employee Delete endpoint");
            return await _employeeService.DeleteEmployeeAsync(employeeCode);
        }
    }
}