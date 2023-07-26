using System.Collections.Generic;
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
        public IEnumerable<CompanyDto> GetAll()
        {
            return _mapper.Map<IEnumerable<CompanyDto>>(_companyService.GetAllCompanies());
        }

        // GET api/<controller>/5
        public CompanyDto Get(string companyCode)
        {
            return _mapper.Map<CompanyDto>(_companyService.GetCompanyByCode(companyCode));
        }

        // POST api/<controller>
        public bool Post([FromBody] CompanyDto company)
        {
            return _companyService.CreateCompany(_mapper.Map<CompanyInfo>(company));
        }

        // PUT api/<controller>/5
        public bool Put(string companyCode, [FromBody] CompanyDto company)
        {
            return _companyService.UpdateCompany(_mapper.Map<CompanyInfo>(company));
        }

        // DELETE api/<controller>/5
        public bool Delete(string companyCode)
        {
            return _companyService.DeleteCompany(companyCode);
        }
    }
}