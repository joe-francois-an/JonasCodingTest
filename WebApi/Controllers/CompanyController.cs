using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using WebApi.Models;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService, IMapper mapper, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET api/<controller>
        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            _logger.LogInformation("Company GetAll endpoint");
            return _mapper.Map<IEnumerable<CompanyDto>>(await _companyService.GetAllCompaniesAsync());
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("{companyCode}")]
        public async Task<CompanyDto> Get(string companyCode)
        {
            _logger.LogInformation("Company Get endpoint");
            return _mapper.Map<CompanyDto>(await _companyService.GetCompanyByCodeAsync(companyCode));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<bool> Post([FromBody] CompanyDto company)
        {
            _logger.LogInformation("Company Post endpoint");
            return await _companyService.CreateCompanyAsync(_mapper.Map<CompanyInfo>(company));
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("{companyCode}")]
        public async Task<bool> Put(string companyCode, [FromBody] CompanyDto company)
        {
            _logger.LogInformation("Company Put endpoint");
            return await _companyService.UpdateCompanyAsync(_mapper.Map<CompanyInfo>(company));
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{companyCode}")]
        public async Task<bool> Delete(string companyCode)
        {
            _logger.LogInformation("Company Delete endpoint");
            return await _companyService.DeleteCompanyAsync(companyCode);
        }
    }
}