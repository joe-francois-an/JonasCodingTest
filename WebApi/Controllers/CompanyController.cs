using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<CompanyDto>>(await _companyService.GetAllCompaniesAsync());
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            return _mapper.Map<CompanyDto>(await _companyService.GetCompanyByCodeAsync(companyCode));
        }

        // POST api/<controller>
        public async Task<bool> Post([FromBody] CompanyDto company)
        {
            return await _companyService.CreateCompanyAsync(_mapper.Map<CompanyInfo>(company));
        }

        // PUT api/<controller>/5
        public async Task<bool> Put(string companyCode, [FromBody] CompanyDto company)
        {
            return await _companyService.UpdateCompanyAsync(_mapper.Map<CompanyInfo>(company));
        }

        // DELETE api/<controller>/5
        public async Task<bool> Delete(string companyCode)
        {
            return await _companyService.DeleteCompanyAsync(companyCode);
        }
    }
}